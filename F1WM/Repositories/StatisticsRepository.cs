using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public class StatisticsRepository : RepositoryBase, IStatisticsRepository
	{
		private readonly IMapper mapper;

		public Task<DriverStatistics> GetDriverStatistics(int driverId)
		{
			throw new System.NotImplementedException();
		}

		public StatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}
	}
}
