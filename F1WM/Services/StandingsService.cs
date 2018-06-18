using System.Threading.Tasks;
using F1WM.ApiModel;
using System.Linq;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StandingsService : IStandingsService
	{
		private IStandingsRepository repository;

		public async Task<ConstructorsStandings> GetConstructorsStandings(int count, int? seasonId)
		{
			var model = await repository.GetConstructorsStandings(count, seasonId);
			return model;
		}

		public async Task<DriversStandings> GetDriversStandings(int count, int? seasonId)
		{
			var model = await repository.GetDriversStandings(count, seasonId);
			return model;
		}

		public StandingsService(IStandingsRepository repository)
		{
			this.repository = repository;
		}
	}
}