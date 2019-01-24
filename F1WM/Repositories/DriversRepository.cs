using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Repositories
{
	public class DriversRepository : RepositoryBase, IDriversRepository
	{
		private readonly IMapper mapper;

		public async Task<Drivers> GetDrivers(char letter)
		{
			await SetDbEncoding();

			Drivers result = new Drivers();

			result.DriversList = await mapper.ProjectTo<DriverSummary>(
				context.Drivers
					.Where(d => d.Litera == letter.ToString())
					.OrderBy(d => d.Surname))
				.ToListAsync();

			return (result.DriversList.Any()) ? result : null;
		}

		public DriversRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
