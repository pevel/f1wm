using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class RacesRepository : RepositoryBase, IRacesRepository
	{
		private readonly IMapper mapper;

		public async Task<NextRaceSummary> GetNextRace(SeasonRaces currentSeason)
		{
			if (currentSeason != null)
			{
				Expression<Func<Race, bool>> filter = currentSeason.GetNextRaceFilter();
				var dbNextRace = await context.Races
					.OrderBy(r => r.Date)
					.Include(r => r.Track)
					.Include(r => r.Country)
					.FirstOrDefaultAsync(filter);
				if (dbNextRace != null)
				{
					var apiNextRace = mapper.Map<NextRaceSummary>(dbNextRace);
					await IncludeLastPolePositionResult(dbNextRace, apiNextRace);
					await IncludeLastWinnerResult(dbNextRace, apiNextRace);
					await IncludeLastFastestResult(dbNextRace, apiNextRace);
					return apiNextRace;
				}
			}
			return null;
		}

		public async Task<LastRaceSummary> GetMostRecentRace(SeasonRaces currentSeason)
		{
			if (currentSeason != null)
			{
				Expression<Func<Race, bool>> filter = currentSeason.GetMostRecentRaceFilter();
				var dbLastRace = await context.Races
					.OrderByDescending(r => r.Date)
					.Include(r => r.Track)
					.Include(r => r.Country)
					.Include(r => r.RaceNews)
					.FirstOrDefaultAsync(filter);
				if (dbLastRace != null)
				{
					await IncludeFastestLap(dbLastRace.Date.AddSeconds(1));
					var apiLastRace = mapper.Map<LastRaceSummary>(dbLastRace);
					await IncludePolePositionResult(dbLastRace, apiLastRace);
					return apiLastRace;
				}
			}
			return null;
		}

		public async Task<NextRaceSummary> GetFirstRaceAfter(DateTime afterDate)
		{
			var dbNextRace = await context.Races
				.OrderBy(r => r.Date)
				.Include(r => r.Track)
				.Include(r => r.Country)
				.FirstOrDefaultAsync(r => r.Date > afterDate);
			var apiNextRace = mapper.Map<NextRaceSummary>(dbNextRace);
			await IncludeLastPolePositionResult(dbNextRace, apiNextRace);
			await IncludeLastWinnerResult(dbNextRace, apiNextRace);
			await IncludeLastFastestResult(dbNextRace, apiNextRace);
			return apiNextRace;
		}

		public async Task<LastRaceSummary> GetMostRecentRaceBefore(DateTime beforeDate)
		{
			var dbLastRace = await context.Races
				.OrderByDescending(r => r.Date)
				.Include(r => r.Track)
				.Include(r => r.Country)
				.Include(r => r.RaceNews)
				.FirstOrDefaultAsync(r => r.Date < beforeDate);
			await IncludeFastestLap(beforeDate);
			var apiLastRace = mapper.Map<LastRaceSummary>(dbLastRace);
			await IncludePolePositionResult(dbLastRace, apiLastRace);
			return apiLastRace;
		}

		public Task<ApiModel.RaceNews> GetRaceNews(int raceId)
		{
			return mapper.ProjectTo<ApiModel.RaceNews>(context.RaceNews
					.Where(n => n.RaceId == raceId))
				.FirstOrDefaultAsync();
		}

		public async Task<RaceFastestLaps> GetRaceFastestLaps(int raceId)
		{
			var apiFastestLaps = new RaceFastestLaps() { RaceId = raceId };
			apiFastestLaps.Results = await mapper.ProjectTo<RaceFastestLap>(context.FastestLaps
					.Where(f => f.RaceId == raceId)
					.OrderBy(f => f.Time))
				.ToListAsync();
			return apiFastestLaps.Results.Any() ? apiFastestLaps : null;
		}

		public RacesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task IncludeFastestLap(DateTime beforeDate)
		{
			var dbFastestLap = await context.FastestLaps
				.Include(f => f.Entry).ThenInclude(f => f.Race)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Include(f => f.Entry).ThenInclude(e => e.Driver)
				.OrderByDescending(f => f.Entry.Race.Date)
				.Where(f => f.Entry.Race.Date < beforeDate && f.PositionOrStatus == "1")
				.FirstOrDefaultAsync();
		}

		private async Task IncludeLastWinnerResult(Race dbNextRace, NextRaceSummary apiNextRace)
		{
			var dbLastWinnerResult = await context.Results
				.Include(r => r.Race)
				.Where(r => r.Race.TrackId == dbNextRace.TrackId && r.Race.Date < dbNextRace.Date && r.PositionOrStatus == "1")
				.Include(r => r.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.OrderByDescending(r => r.Race.Date)
				.FirstOrDefaultAsync();
			apiNextRace.LastWinnerRaceResult = mapper.Map<RaceResultSummary>(dbLastWinnerResult?.Entry);
		}

		private async Task IncludeLastPolePositionResult(Race dbNextRace, NextRaceSummary apiNextRace)
		{
			var dbLastPolePositionResult = await context.Grids
				.Include(g => g.Race)
				.Where(g => g.Race.TrackId == dbNextRace.TrackId && g.Race.Date < dbNextRace.Date && g.StartPositionOrStatus == "1")
				.Include(g => g.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.OrderByDescending(g => g.Race.Date)
				.FirstOrDefaultAsync();
			apiNextRace.LastPolePositionLapResult = mapper.Map<LapResultSummary>(dbLastPolePositionResult?.Entry);
		}

		private async Task IncludeLastFastestResult(Race dbNextRace, NextRaceSummary apiNextRace)
		{
			var dbFastestResult = await context.Entries
				.Include(e => e.Race)
				.Include(e => e.FastestLap)
				.Where(e => e.Race.TrackId == dbNextRace.TrackId && e.Race.Date < dbNextRace.Date && e.FastestLap.PositionOrStatus == "1")
				.Include(e => e.Driver).ThenInclude(d => d.Nationality)
				.OrderByDescending(e => e.Race.Date)
				.FirstOrDefaultAsync();
			apiNextRace.LastFastestLapResult = mapper.Map<LapResultSummary>(dbFastestResult);
		}

		private async Task IncludePolePositionResult(Race dbLastRace, LastRaceSummary apiLastRace)
		{
			var dbPolePositionResult = await context.Grids
				.Include(g => g.Race)
				.Include(g => g.Entry).ThenInclude(e => e.Driver)
				.SingleOrDefaultAsync(g => g.Race.Id == dbLastRace.Id && g.StartPositionOrStatus == "1");
			apiLastRace.PolePositionLapResult = mapper.Map<LapResultSummary>(dbPolePositionResult?.Entry);
		}
	}
}
