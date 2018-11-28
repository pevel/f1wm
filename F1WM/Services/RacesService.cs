using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
    public class RacesService : IRacesService
	{
		private readonly IRacesRepository repository;
		private readonly ITimeService time;

		public Task<NextRaceSummary> GetNextRace()
		{
			return repository.GetFirstRaceAfter(time.Now);
		}

		public RacesService(IRacesRepository repository, ITimeService time)
		{
			this.repository = repository;
			this.time = time;
		}
	}
}