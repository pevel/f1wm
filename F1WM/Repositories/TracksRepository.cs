using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using AutoMapper;
using System.Linq.Expressions;
using F1WM.DatabaseModel.Constants;
using F1WM.Utilities;
using F1WM.DomainModel;
using System.Collections.Generic;

namespace F1WM.Repositories
{
	public class TracksRepository : RepositoryBase, ITracksRepository
	{
		private readonly IMapper mapper;
		private readonly Expression<Func<Qualifying, bool>> hasFastestLap =
			q => q.Session1Position == 1 ||
				q.Session2Position == 1 ||
				q.Session3Position == 1 ||
				(q.Session1Position == 0 && q.PositionOrStatus == "1");


		public async Task<TrackDetails> GetTrack(int id, int atYear)
		{
			var dbTrack = await context.Tracks
				.Include(t => t.Country)
				.Include(t => t.Website)
				.SingleOrDefaultAsync(t => t.Id == id);
			await context.Entry(dbTrack)
				.Collection(t => t.Races)
				.Query()
				.Where(r => r.Date.Year <= atYear)
				.Include(r => r.Country)
				.OrderByDescending(r => r.Date)
				.FirstOrDefaultAsync();
			return dbTrack != null ? mapper.Map<TrackDetails>(dbTrack) : null;
		}

		public async Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear)
		{
			var dbFastestQualifyingLapInNewFormat = await GetFastestQualifyingLapInNewFormat(trackId, trackVersion, beforeYear);
			var dbFastestQualifyingLapInOldFormat = await GetFastestQualifyingLapInOldFormat(trackId, trackVersion, beforeYear);
			var dbBestAverageSpeedResult = await GetBestAverageSpeedResult(trackId, trackVersion, beforeYear);
			var dbFastestLap = await GetFastestLap(trackId, trackVersion, beforeYear);
			if (dbFastestQualifyingLapInNewFormat == null && dbBestAverageSpeedResult == null && dbFastestLap == null)
			{
				return null;
			}
			else
			{
				return new TrackRecordsInformation()
				{
					TrackId = trackId,
					TrackVersion = trackVersion,
					BeforeYear = beforeYear,
					FastestQualifyingLapResult = GetFastestQualifyingLap(
						dbFastestQualifyingLapInNewFormat,
						dbFastestQualifyingLapInOldFormat),
					FastestRaceLapResult = mapper.Map<FastestLapResultSummary>(dbFastestLap),
					BestAverageSpeedResult = mapper.Map<AverageSpeedResult>(dbBestAverageSpeedResult)
				};
			}
		}

		public Task<PagedResult<ApiModel.Track>> GetTracks(uint page, uint countPerPage)
		{
			var dbTracks = context.Tracks
				.OrderByDescending(t => t.Status)
				.ThenBy(t => t.ShortName);
			return dbTracks.GetPagedResult<DatabaseModel.Track, ApiModel.Track>(mapper, page, countPerPage);
		}

		public Task<PagedResult<ApiModel.Track>> GetTracksByStatus(byte status, uint page, uint countPerPage)
		{
			var dbTracks = context.Tracks
				.Where(t => t.Status == status)
				.OrderBy(t => t.ShortName);
			return dbTracks.GetPagedResult<DatabaseModel.Track, ApiModel.Track>(mapper, page, countPerPage);
		}

		public async Task<TrackShortResultsByYears> GetShortResultsByYears(int trackId, int untilYear)
		{
			var years = await GetTrackYears(trackId, untilYear);
			if (years.Any())
			{
				var raceIds = years.Select(y => y.RaceId);
				var polePositions = await GetPolePositions(raceIds, untilYear);
				var fastestLaps = await GetFastestLaps(raceIds, untilYear);
				var winners = await GetWinnersResults(raceIds, untilYear);
				var results = new TrackShortResultsByYears()
				{
					TrackId = trackId,
					CurrentTrackVersion = years.OrderByDescending(y => y.Year).First().TrackVersion
				};
				results.Results = years.Select(y => new TrackShortResultsByYear()
				{
					Year = y.Year,
					TrackVersion = y.TrackVersion,
					PolePositionLapResult = polePositions.SingleOrDefault(p => p.Year == y.Year),
					WinnerRaceResult = winners.SingleOrDefault(w => w.Year == y.Year),
					FastestLapResults = fastestLaps.Where(f => f.Year == y.Year)
				})
				.Where(r => r.FastestLapResults.Any() || r.PolePositionLapResult != null || r.WinnerRaceResult != null);
				return results;
			}
			return null;
		}

		public TracksRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}

		private async Task<IEnumerable<TrackYearSummary>> GetTrackYears(int trackId, int untilYear)
		{
			return await context.Races
				.Where(r => r.TrackId == trackId && r.Date.Year <= untilYear)
				.Select(r => new TrackYearSummary()
				{
					Id = r.TrackId,
					RaceId = r.Id,
					Year = r.Season.Year,
					TrackVersion = r.TrackVersion
				})
				.ToListAsync();
		}

		private Task<List<TrackRaceResultSummaryByYear>> GetWinnersResults(IEnumerable<uint> raceIds, int untilYear)
		{
			return mapper.ProjectTo<TrackRaceResultSummaryByYear>(context.Results
					.Where(r => r.PositionOrStatus == "1" && raceIds.Contains(r.RaceId))
					.Where(r => r.Race.Date.Year <= untilYear))
				.ToListAsync();
		}

		private Task<List<TrackLapResultSummaryByYear>> GetFastestLaps(IEnumerable<uint> raceIds, int untilYear)
		{
			return mapper.ProjectTo<TrackLapResultSummaryByYear>(context.FastestLaps
					.Where(f => f.PositionOrStatus == "1" && raceIds.Contains(f.RaceId))
					.Where(r => r.Race.Date.Year <= untilYear))
				.ToListAsync();
		}

		private Task<List<TrackLapResultSummaryByYear>> GetPolePositions(IEnumerable<uint> raceIds, int untilYear)
		{
			return mapper.ProjectTo<TrackLapResultSummaryByYear>(context.Grids
					.Where(g => g.StartPositionOrStatus == "1" && raceIds.Contains(g.RaceId))
					.Where(r => r.Race.Date.Year <= untilYear))
				.ToListAsync();
		}

		private FastestQualifyingLapResultSummary GetFastestQualifyingLap(Qualifying newFormat, Grid oldFormat)
		{
			if (oldFormat?.Time < newFormat.GetFastestQualifyingLapTime())
			{
				return mapper.Map<FastestQualifyingLapResultSummary>(oldFormat);
			}
			else
			{
				return mapper.Map<FastestQualifyingLapResultSummary>(newFormat);
			}
		}

		private async Task<FastestLap> GetFastestLap(int trackId, int trackVersion, int beforeYear)
		{
			return await context.FastestLaps
				.Include(f => f.Race)
				.Include(f => f.Entry).ThenInclude(e => e.Driver)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Where(f => f.Race.TrackId == trackId && f.Race.TrackVersion == trackVersion)
				.Where(f => f.Race.Date.Year < beforeYear)
				.Where(f => f.PositionOrStatus == "1")
				.OrderBy(f => f.Time)
				.FirstOrDefaultAsync();
		}

		private async Task<Result> GetBestAverageSpeedResult(int trackId, int trackVersion, int beforeYear)
		{
			return await context.Results
				.Include(r => r.Race).ThenInclude(r => r.Track)
				.Include(f => f.Entry).ThenInclude(e => e.Driver)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Where(r => r.Race.TrackId == trackId && r.Race.TrackVersion == trackVersion)
				.Where(r => r.Race.Date.Year < beforeYear)
				.Where(r => r.FinishedLaps == r.Race.Laps)
				.OrderBy(r => r.Time)
				.FirstOrDefaultAsync(r => r.Time != TimeSpan.Zero);
		}

		private async Task<Grid> GetFastestQualifyingLapInOldFormat(int trackId, int trackVersion, int beforeYear)
		{
			return await context.Grids
				.Include(g => g.Race)
				.Include(g => g.Entry).ThenInclude(e => e.Driver)
				.Include(g => g.Entry).ThenInclude(e => e.Car)
				.Where(g => g.RaceId < ResultsConstants.SearchInGridBeforeRaceId)
				.Where(g => g.Race.Date.Year < beforeYear)
				.Where(g => g.Race.TrackId == trackId && g.Race.TrackVersion == trackVersion)
				.Where(g => g.Time != TimeSpan.Zero)
				.OrderBy(g => g.Time)
				.FirstOrDefaultAsync();
		}

		private async Task<Qualifying> GetFastestQualifyingLapInNewFormat(int trackId, int trackVersion, int beforeYear)
		{
			return (await context.Qualifying
				.Include(q => q.Race)
				.Include(q => q.Entry).ThenInclude(e => e.Driver)
				.Include(q => q.Entry).ThenInclude(e => e.Car)
				.Where(hasFastestLap)
				.Where(q => q.Race.Date.Year < beforeYear)
				.Where(q => q.Race.TrackId == trackId && q.Race.TrackVersion == trackVersion)
				.ToListAsync())
				.OrderBy(q => (new[] { q.Session1Time, q.Session2Time, q.Session3Time }).Where(t => t != TimeSpan.Zero).Min())
				.FirstOrDefault();
		}
	}
}
