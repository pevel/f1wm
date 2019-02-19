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
				.SingleOrDefaultAsync(t => t.Id == id);
			await context.Entry(dbTrack)
				.Collection(t => t.Races)
				.Query()
				.Where(r => r.Date.Year <= atYear)
				.Include(r => r.Country)
				.OrderByDescending(r => r.Date)
				.FirstOrDefaultAsync();
			return mapper.Map<TrackDetails>(dbTrack);
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

		public TracksRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
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
				.Select(q => new
				{
					Qualifying = q,
					Time = (new[] { q.Session1Time, q.Session2Time, q.Session3Time })
					.Where(t => t != TimeSpan.Zero)
					.Min()
				})
				.OrderBy(g => g.Time)
				.FirstOrDefaultAsync())
				?.Qualifying;
		}
	}
}
