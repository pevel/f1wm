using System.Threading.Tasks;
using F1WM.ApiModel;
using System.Linq;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StandingsService : IStandingsService
	{
		private IStandingsRepository repository;

		public async Task<ConstructorsStandings> GetConstructorsStandings(int? seasonId)
		{
			var model = await repository.GetConstructorsStandings();
			model.Standings = model.Standings.OrderBy(s => s.Position).ToList();
			return model;
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