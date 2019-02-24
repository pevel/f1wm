using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IStatisticsService
	{
		Task<DriverStatistics> GetDriverStatistics(int driverId, int? atYear);
		Task<EngineStatistics> GetEngineStatistics(int engineId, int? atYear);
		Task<TeamStatistics> GetTeamStatistics(int teamId, int? atYear);
	}
}
