using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class TeamsRepository : RepositoryBase, ITeamsRepository
	{
		private readonly IMapper mapper;

		public async Task<TeamDetails> GetTeam(int id)
		{
			var dbTeam = await context.Teams
				.Include(t => t.Country)
				.FirstOrDefaultAsync(t => t.Id == id);
			if (dbTeam != null)
			{
				var apiTeam = mapper.Map<TeamDetails>(dbTeam);
				await IncludeWebsite(dbTeam.Key, apiTeam);
				await IncludeFullName(id, apiTeam);
				await IncludeCar(id, apiTeam);
				await IncludeTestDrivers(id, apiTeam);
				await IncludeRacesInfo(id, apiTeam);
				return apiTeam;
			}
			else
			{
				return null;
			}
		}

		public async Task<Teams> GetTeams(char letter)
		{
			var apiTeams = new Teams();
			apiTeams.TeamsList = await mapper.ProjectTo<TeamSummary>(context.Teams
					.Where(t => t.Letter == letter.ToString())
					.OrderBy(t => t.Name))
				.ToListAsync();
			return apiTeams;
		}

		public TeamsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}

		private async Task IncludeCar(int id, TeamDetails apiTeam)
		{
			apiTeam.Car = await mapper.ProjectTo<CarSummary>(context.Entries
					.OrderByDescending(e => e.Race.Date)
					.Where(e => e.TeamId == id)
					.Select(e => e.Car))
				.FirstOrDefaultAsync();
		}

		private async Task IncludeTestDrivers(int id, TeamDetails apiTeam)
		{
			apiTeam.TestDrivers = await mapper.ProjectTo<DriverSummary>(context.Drivers
					.Where(d => d.Team.Id == id && d.Group == DriverGroup.TestDriver))
				.ToListAsync();
		}

		private async Task IncludeRacesInfo(int id, TeamDetails apiTeam)
		{
			apiTeam.FirstStartAt = await mapper.ProjectTo<RaceSummary>(context.Grids
					.Where(g => g.Entry.TeamId == id)
					.OrderBy(g => g.Race.Date)
					.Select(g => g.Race))
				.FirstOrDefaultAsync();
			apiTeam.FirstWinAt = await mapper.ProjectTo<RaceSummary>(context.Entries
					.Where(e => e.Result.PositionOrStatus == "1")
					.Where(e => e.TeamId == id)
					.OrderBy(e => e.Race.Date)
					.Select(e => e.Race))
				.FirstOrDefaultAsync();
		}

		private async Task IncludeWebsite(string teamKey, TeamDetails apiTeam)
		{
			apiTeam.Website = (await context.Links.SingleOrDefaultAsync(l => l.CategoryKey == teamKey))?.Url;
		}

		private async Task IncludeFullName(int id, TeamDetails apiTeam)
		{
			apiTeam.FullName = await context.Entries
				.Where(e => e.TeamId == id)
				.OrderByDescending(e => e.Race.Date)
				.Select(e => e.TeamName.FullName)
				.FirstOrDefaultAsync();
		}
	}
}
