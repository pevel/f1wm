using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IEntriesService
	{
		Task<RaceEntriesInformation> GetRaceEntries(int raceId);
	}
}
