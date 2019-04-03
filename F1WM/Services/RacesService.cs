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

		public Task<NextRaceSummary> GetNextRace(DateTime? after = null)
		{
			return after != null
				? racesRepository.GetFirstRaceAfter(after.Value)
				: racesRepository.GetNextRace();
		}

		public async Task<LastRaceSummary> GetLastRace(DateTime? before = null)
		{
			var model = before != null
				? await racesRepository.GetMostRecentRaceBefore(before.Value)
				: await racesRepository.GetMostRecentRace();
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
			IResultsRepository resultsRepository)
		{
			this.racesRepository = racesRepository;
			this.resultsRepository = resultsRepository;
		}
	}
}
