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

		public Task<NextRaceSummary> GetNextRace()
		{
			return racesRepository.GetFirstRaceAfter(time.Now);
		}

		public async Task<LastRaceSummary> GetLastRace()
		{
			var model = await racesRepository.GetMostRecentRaceBefore(time.Now);
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
