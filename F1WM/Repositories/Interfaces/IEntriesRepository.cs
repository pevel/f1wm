using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IEntriesRepository
	{
		Task<RaceEntriesInformation> GetRaceEntries(int raceId);
		Task<SeasonEntriesInformation> GetSeasonEntries(int year);
	}
}
