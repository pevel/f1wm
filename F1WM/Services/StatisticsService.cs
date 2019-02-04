using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly ITimeService time;
		private readonly IStatisticsRepository repository;

		public Task<DriverStatistics> GetDriverStatistics(int driverId, int? atYear)
		{
			return repository.GetDriverStatistics(driverId, atYear ?? time.Now.Year);
		}

		public StatisticsService(IStatisticsRepository repository, ITimeService time)
		{
			this.time = time;
			this.repository = repository;
		}
	}
}
