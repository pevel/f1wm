using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IStandingsRepository
	{
		Task<ConstructorsStandings> GetConstructorsStandings(int? seasonId);
		Task<DriversStandings> GetDriversStandings(int? seasonId);
	}
}