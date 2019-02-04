using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IStatisticsRepository repository;

		public Task<DriverStatistics> GetDriverStatistics(int driverId)
		{
			return repository.GetDriverStatistics(driverId);
		}

		public StatisticsService(IStatisticsRepository repository)
		{
			this.repository = repository;
		}
	}
}
