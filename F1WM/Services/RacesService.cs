using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class RacesService : IRacesService
	{
		private readonly IRacesRepository racesRepository;
		private readonly IResultsRepository resultsRepository;
		private readonly ISeasonsRepository seasonsRepository;
		private readonly ITimeService time;

		public async Task<NextRaceSummary> GetNextRace(DateTime? after = null)
		{
			return after != null
				? await racesRepository.GetFirstRaceAfter(after.Value)
				: await racesRepository.GetNextRace(await seasonsRepository.GetCurrentSeasonRaces(time.Now));
		}

		public async Task<LastRaceSummary> GetLastRace(DateTime? before = null)
		{
			var model = before != null
				? await racesRepository.GetMostRecentRaceBefore(before.Value)
				: await racesRepository.GetMostRecentRace(await seasonsRepository.GetCurrentSeasonRaces(time.Now));
			if (model != null)
			{
				model.ShortResults = await resultsRepository.GetShortRaceResult(model.Id);
				return model;
			}
			return null;
		}

		public Task<RaceFastestLaps> GetRaceFastestLaps(int raceId)
		{
			return racesRepository.GetRaceFastestLaps(raceId);
		}

		public Task<RaceNews> GetRaceNews(int raceId)
		{
			return racesRepository.GetRaceNews(raceId);
		}

		public RacesService(
			IRacesRepository racesRepository,
			IResultsRepository resultsRepository,
			ISeasonsRepository seasonsRepository,
			ITimeService time)
		{
			this.racesRepository = racesRepository;
			this.resultsRepository = resultsRepository;
			this.seasonsRepository = seasonsRepository;
			this.time = time;
		}
	}
}
