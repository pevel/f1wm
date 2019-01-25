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
			var apiDriver = await mapper.ProjectTo<DriverDetails>(GetDriver(id)).FirstOrDefaultAsync();
			await IncludeLastEntryInfo(id, atYear, apiDriver);
			await IncludeF1ChampionshipInfo(id, atYear, apiDriver);
			await IncludeRacesInfo(id, atYear, apiDriver);
			return apiDriver;
		}

		public DriversRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task IncludeLastEntryInfo(int id, int atYear, DriverDetails apiDriver)
		{
			Entry dbLastEntry = await context.Entries
				.Include(e => e.Race)
				.Include(e => e.Car)
				.Include(e => e.Team)
				.OrderByDescending(e => e.Race.Date)
				.FirstOrDefaultAsync(e => e.DriverId == id && e.Race.Date.Year <= atYear);
			apiDriver.Number = dbLastEntry.Number;
			apiDriver.Car = mapper.Map<CarSummary>(dbLastEntry.Car);
			apiDriver.Team = mapper.Map<TeamSummary>(dbLastEntry.Team);
		}

		private IQueryable<Driver> GetDriver(int id)
		{
			return context.Drivers
				.Include(d => d.Link)
				.Where(d => d.Id == id);
		}

		private async Task IncludeF1ChampionshipInfo(int id, int atYear, DriverDetails apiDriver)
		{
			apiDriver.F1ChampionAtYears = await context.DriverStandingsPositions
				.Include(s => s.Season)
				.Where(s => s.DriverId == id && s.Season.Year <= atYear && s.Position == 1)
				.Select(s => s.Season.Year)
				.ToListAsync();
			apiDriver.F1ChampionAtYears = apiDriver.F1ChampionAtYears.Any() ? apiDriver.F1ChampionAtYears : null;
		}

		private async Task IncludeRacesInfo(int id, int atYear, DriverDetails apiDriver)
		{
			apiDriver.FirstStartAt = await mapper.ProjectTo<DriverDetailsRaceSummary>(context.Grids
					.Include(g => g.Entry)
					.Include(g => g.Race)
					.Where(g => g.Entry.DriverId == id && g.Race.Date.Year <= atYear)
					.OrderBy(g => g.Race.Date)
					.Select(g => g.Race))
				.FirstOrDefaultAsync();
			apiDriver.FirstWinAt = await mapper.ProjectTo<DriverDetailsRaceSummary>(context.Entries
					.Include(e => e.Race)
					.Include(e => e.Result)
					.Where(e => e.Result.PositionOrStatus == "1")
					.Where(e => e.DriverId == id && e.Race.Date.Year <= atYear)
					.OrderBy(e => e.Race.Date)
					.Select(e => e.Race))
				.FirstOrDefaultAsync();
		}
	}
}
