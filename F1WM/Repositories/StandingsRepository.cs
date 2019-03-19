using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class StandingsRepository : RepositoryBase, IStandingsRepository
	{
		private readonly IMapper mapper;

		public async Task<ConstructorsStandings> GetConstructorsStandings(int count, int? seasonId = null)
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
			model.Positions = await GetConstructorsStandingsBySeasonId(count, seasonId.Value);
			return model;
		}

		public async Task<DriversStandings> GetDriversStandings(int count, int? seasonId = null)
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
			model.Positions = await GetDriverStandingsBySeasonId(count, seasonId.Value);
			return model;
		}

		public async Task<ConstructorsStandingsAfterRace> GetConstructorsStandingsAfterRace(int raceId)
		{
			var constraints = await context.Races
				.Where(r => r.Id == raceId)
				.Select(r => new { r.SeasonId, r.Date })
				.SingleOrDefaultAsync();
			if (constraints != null)
			{
				var model = new ConstructorsStandingsAfterRace() { RaceId = raceId };
				model.Positions = await GetConstructorsStandingsAfterRace(constraints.SeasonId, constraints.Date);
				return model;
			}
			return null;
		}

		public async Task<DriversStandingsAfterRace> GetDriversStandingsAfterRace(int raceId)
		{
			throw new System.NotImplementedException();
		}

		public StandingsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task<IEnumerable<ConstructorPosition>> GetConstructorsStandingsBySeasonId(int count, int seasonId)
		{
			var dbStandings = await context.ConstructorStandingsPositions
				.Include(cs => cs.Constructor)
					.ThenInclude(c => c.Nationality)
				.Where(cs => cs.SeasonId == seasonId)
				.OrderBy(cs => cs.Position)
				.Take(count)
				.ToListAsync();
			return mapper.Map<IEnumerable<ConstructorPosition>>(dbStandings);
		}

		private async Task<IEnumerable<DriverPosition>> GetDriverStandingsBySeasonId(int count, int seasonId)
		{
			var dbStandings = await context.DriverStandingsPositions
				.Include(ds => ds.Driver)
					.ThenInclude(d => d.Nationality)
				.Where(ds => ds.SeasonId == seasonId)
				.OrderBy(ds => ds.Position)
				.Take(count)
				.ToListAsync();
			return mapper.Map<IEnumerable<DriverPosition>>(dbStandings);
		}

		private async Task<IEnumerable<ConstructorPositionAfterRace>> GetConstructorsStandingsAfterRace(uint seasonId, DateTime date)
		{
			var positions = await context.ConstructorPoints
				.Where(c => c.SeasonId == seasonId && c.Race.Date <= date)
				.Include(c => c.Constructor).ThenInclude(c => c.Nationality)
				.Select(c => new { c, c.Constructor })
				.GroupBy(c => c.c.ConstructorId, (key, result) => new ConstructorPositionAfterRace() 
				{
					Id = key,
					Constructor = mapper.Map<ConstructorSummary>(result.FirstOrDefault().Constructor),
					NotCountedTowardsChampionshipPoints = result.Sum(c => c.c.NotCountedTowardsChampionshipPoints ?? 0),
					Points = result.Sum(c => c.c.Points ?? 0)
				})
				.OrderByDescending(c => c.Points)
				.ToListAsync();
			foreach (var pair in positions.Select((position, index) => new { position, index }))
			{
				pair.position.Position = pair.index + 1;
			}
			return positions;
		}
	}
}
