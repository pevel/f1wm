using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class StandingsRepository : IStandingsRepository
	{
		private F1WMContext context;
		private IMapper mapper;

		public async Task<ConstructorsStandings> GetConstructorsStandings(int? seasonId = null)
		{
			var model = new ConstructorsStandings();
			if (seasonId == null)
			{
				seasonId = await context.Seasons
					.Join(context.ConstructorStandingsPositions, s => s.Id, c => c.SeasonId, (s, c) => new { s, c })
					.Where(g => g.c != null)
					.Select(g => g.s)
					.OrderByDescending(s => s.Year)
					.Select(s => (int)s.Id)
					.FirstAsync();
			}
			model.Standings = await GetConstructorsStandingsBySeasonId(seasonId.Value);
			return model;
		}

		public async Task<DriversStandings> GetDriversStandings(int? seasonId)
		{
			var model = new DriversStandings();
			if (seasonId == null)
			{
				seasonId = await context.Seasons
					.Join(context.DriverStandingsPositions, s => s.Id, d => d.SeasonId, (s, d) => new { s, d })
					.Where(g => g.d != null)
					.Select(g => g.s)
					.OrderByDescending(s => s.Year)
					.Select(s => (int)s.Id)
					.FirstAsync();
			}
			model.Standings = await GetDriverStandingsBySeasonId(seasonId.Value);
			return model;
		}

		public StandingsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task<IEnumerable<ConstructorPosition>> GetConstructorsStandingsBySeasonId(int seasonId)
		{
			var dbStandings = await context.ConstructorStandingsPositions
				.Include(cs => cs.CarMake)
				.Where(cs => cs.SeasonId == seasonId)
				.ToListAsync();
			return mapper.Map<IEnumerable<ConstructorPosition>>(dbStandings);
		}

		private async Task<IEnumerable<DriverPosition>> GetDriverStandingsBySeasonId(int seasonId)
		{
			var dbStandings = await context.DriverStandingsPositions
				.Include(ds => ds.Driver)
				.Where(ds => ds.SeasonId == seasonId)
				.ToListAsync();
			return mapper.Map<IEnumerable<DriverPosition>>(dbStandings);
		}
	}
}