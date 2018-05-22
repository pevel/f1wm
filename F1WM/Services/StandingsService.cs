using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StandingsService : IStandingsService
	{
		private IStandingsRepository repository;

		public Task<ConstructorsStandings> GetConstructorsStandings(int? seasonId)
		{
			return this.repository.GetConstructorsStandings(seasonId);
		}

		public Task<DriversStandings> GetDriversStandings(int? seasonId)
		{
			throw new System.NotImplementedException();
		}

		public StandingsService(IStandingsRepository repository)
		{
			this.repository = repository;
		}
	}
}