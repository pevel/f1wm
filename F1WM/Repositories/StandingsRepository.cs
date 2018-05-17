using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public class StandingsRepository : IStandingsRepository
	{
		public Task<ConstructorsStandings> GetConstructorsStandings(int? seasonId)
		{
			throw new System.NotImplementedException();
		}

		public Task<DriversStandings> GetDriversStandings(int? seasonId)
		{
			throw new System.NotImplementedException();
		}
	}
}