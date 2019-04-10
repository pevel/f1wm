using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StandingsService : IStandingsService
	{
		private readonly IStandingsRepository repository;

		public Task<ConstructorsStandings> GetConstructorsStandings(int count, int? seasonId)
		{
			return repository.GetConstructorsStandings(count, seasonId);
		}

		public Task<DriversStandings> GetDriversStandings(int count, int? seasonId)
		{
			return repository.GetDriversStandings(count, seasonId);
		}

		public Task<ConstructorsStandingsAfterRace> GetConstructorsStandingsAfterRace(int raceId)
		{
			return repository.GetConstructorsStandingsAfterRace(raceId);
		}

		public Task<DriversStandingsAfterRace> GetDriversStandingsAfterRace(int raceId)
		{
			return repository.GetDriversStandingsAfterRace(raceId);
		}

		public StandingsService(IStandingsRepository repository)
		{
			this.repository = repository;
		}
	}
}
