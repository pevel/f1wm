using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IStandingsRepository
	{
		Task<ConstructorsStandings> GetConstructorsStandings(int count, int? seasonId = null);
		Task<DriversStandings> GetDriversStandings(int count, int? seasonId = null);
		Task<ConstructorsStandingsAfterRace> GetConstructorsStandingsAfterRace(int raceId);
		Task<DriversStandingsAfterRace> GetDriversStandingsAfterRace(int raceId);
	}
}
