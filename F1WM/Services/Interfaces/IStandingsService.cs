using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IStandingsService
	{
		Task<ConstructorsStandings> GetConstructorsStandings(int count, int? seasonId);
		Task<DriversStandings> GetDriversStandings(int count, int? seasonId);
		Task<ConstructorsStandingsAfterRace> GetConstructorsStandingsAfterRace(int raceId);
		Task<DriversStandingsAfterRace> GetDriversStandingsAfterRace(int raceId);
	}
}
