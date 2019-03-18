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
		private readonly ITimeService time;

		public Task<NextRaceSummary> GetNextRace(DateTime? after)
		{
			after = after ?? time.Now;
			return racesRepository.GetFirstRaceAfter(after.Value);
		}

		public async Task<LastRaceSummary> GetLastRace(DateTime? before)
		{
			before = before ?? time.Now;
			var model = await racesRepository.GetMostRecentRaceBefore(before.Value);
			model.ShortResults = await resultsRepository.GetShortRaceResult(model.Id);
			return model;
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
			ITimeService time)
		{
			this.racesRepository = racesRepository;
			this.resultsRepository = resultsRepository;
			this.time = time;
		}
	}
}
