using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IStatisticsRepository
	{
		Task<DriverStatistics> GetDriverStatistics(int driverId, int atYear);
	}
}
