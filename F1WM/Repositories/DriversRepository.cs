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
			Drivers result = new Drivers();

			result.DriversList = await mapper.ProjectTo<DriverSummary>(
				context.Drivers
					.Where(d => d.Litera == letter.ToString())
					.OrderBy(d => d.Surname))
				.ToListAsync();

			return (result.DriversList.Any()) ? result : null;
		}

		public async Task<DriverDetails> GetDriver(int id, int atYear)
		{
			var dbDrivers = context.Drivers
				.Where(d => d.Id == id);
			var dbLastEntry = await context.Entries
				.Include(e => e.Race)
				.Include(e => e.Car)
				.Include(e => e.Team)
				.OrderByDescending(e => e.Race.Date)
				.FirstOrDefaultAsync(e => e.DriverId == id && e.Race.Date.Year <= atYear);
			var apiDriver = await mapper.ProjectTo<DriverDetails>(dbDrivers).FirstOrDefaultAsync();
			apiDriver.Number = dbLastEntry.Number;
			apiDriver.CurrentCar = mapper.Map<CarSummary>(dbLastEntry.Car);
			apiDriver.CurrentTeam = mapper.Map<TeamSummary>(dbLastEntry.Team);
			return apiDriver;
		}

		public DriversRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
