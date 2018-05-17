using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public class StandingsService : IStandingsService
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