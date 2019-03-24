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
					.Select(s => (int) s.Id)
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
					.Select(s => (int) s.Id)
					.FirstAsync();
			}
			model.Positions = await GetDriverStandingsBySeasonId(count, seasonId.Value);
			return model;
		}

		public async Task<ConstructorsStandingsAfterRace> GetConstructorsStandingsAfterRace(int raceId)
		{
			var constraints = context.Races
				.Where(r => r.Id == raceId)
				.Select(r => new { r.SeasonId, r.Date, IsFirst = r.OrderInSeason == 1 })
				.SingleOrDefault();
			if (constraints != null)
			{
				var model = new ConstructorsStandingsAfterRace() { RaceId = raceId };
				model.Positions = await GetConstructorsStandingsAfterRace(
					(constraints.SeasonId, constraints.Date, constraints.IsFirst));
				return model.Positions.Any() ? model : null;
			}
			return null;
		}

		public async Task<DriversStandingsAfterRace> GetDriversStandingsAfterRace(int raceId)
		{
			var constraints = await context.Races
				.Where(r => r.Id == raceId)
				.Select(r => new { r.SeasonId, r.Date, IsFirst = r.OrderInSeason == 1 })
				.SingleOrDefaultAsync();
			if (constraints != null)
			{
				var model = new DriversStandingsAfterRace() { RaceId = raceId };
				model.Positions = await GetDriversStandingsAfterRace(
					(constraints.SeasonId, constraints.Date, constraints.IsFirst));
				return model.Positions.Any() ? model : null;
			}
			return null;
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

		private async Task<IEnumerable<ConstructorPositionAfterRace>> GetConstructorsStandingsAfterRace(
			(uint SeasonId, DateTime Date, bool IsFirst) constraints)
		{
			var positionsAfter = await context.ConstructorPoints
				.Where(p => p.SeasonId == constraints.SeasonId && p.Race.Date <= constraints.Date)
				.Include(p => p.Constructor).ThenInclude(c => c.Nationality)
				.Select(p => new { p, p.Constructor })
				.GroupBy(g => g.p.ConstructorId, (key, result) => new ConstructorPositionAfterRace()
				{
					Id = key,
					Constructor = mapper.Map<ConstructorSummary>(result.FirstOrDefault().Constructor),
					NotCountedTowardsChampionshipPoints = result.Sum(p => p.p.NotCountedTowardsChampionshipPoints ?? 0),
					Points = result.Sum(p => p.p.Points ?? 0)
				})
				.OrderByDescending(p => p.Points)
				.ToListAsync();
			var positionsBefore = await context.ConstructorPoints
				.Where(c => !constraints.IsFirst)
				.Where(c => c.SeasonId == constraints.SeasonId && c.Race.Date < constraints.Date)
				.GroupBy(c => c.ConstructorId, (key, result) => new
				{
					Id = key,
					Points = result.Sum(c => c.Points ?? 0)
				})
				.OrderByDescending(c => c.Points)
				.ToListAsync();
			positionsAfter = positionsAfter
				.Select((position, index) => new { Value = position, index })
				.GroupJoin(positionsBefore.Select((position, index) => new { Id = position.Id, index }),
					after => after.Value.Id,
					before => before.Id,
					(after, beforeGroup) => new { after, beforeGroup })
				.SelectMany(
					g => g.beforeGroup.DefaultIfEmpty(),
					(g, before) => new ConstructorPositionAfterRace()
					{
						Id = g.after.Value.Id,
						Constructor = g.after.Value.Constructor,
						NotCountedTowardsChampionshipPoints = g.after.Value.NotCountedTowardsChampionshipPoints,
						Points = g.after.Value.Points,
						Position = g.after.index + 1,
						Change = before == null ? 0 : (before.index + 1) - (g.after.index + 1)
					})
				.OrderBy(c => c.Position)
				.ToList();
			return positionsAfter;
		}

		private async Task<IEnumerable<DriverPositionAfterRace>> GetDriversStandingsAfterRace(
			(uint SeasonId, DateTime Date, bool IsFirst) constraints)
		{
			var positionsAfter = await context.DriverPoints
				.Where(p => p.SeasonId == constraints.SeasonId && p.Race.Date <= constraints.Date)
				.Include(p => p.Driver).ThenInclude(d => d.Nationality)
				.Select(p => new { p, p.Driver })
				.GroupBy(g => g.p.DriverId, (key, result) => new DriverPositionAfterRace()
				{
					Id = key,
					Driver = mapper.Map<DriverSummary>(result.FirstOrDefault().Driver),
					NotCountedTowardsChampionshipPoints = result.Sum(p => p.p.NotCountedTowardsChampionshipPoints ?? 0),
					Points = result.Sum(p => p.p.Points ?? 0)
				})
				.OrderByDescending(p => p.Points)
				.ToListAsync();
			var positionsBefore = await context.DriverPoints
				.Where(c => !constraints.IsFirst)
				.Where(c => c.SeasonId == constraints.SeasonId && c.Race.Date < constraints.Date)
				.GroupBy(c => c.DriverId, (key, result) => new
				{
					Id = key,
					Points = result.Sum(c => c.Points ?? 0)
				})
				.OrderByDescending(c => c.Points)
				.ToListAsync();
			positionsAfter = positionsAfter
				.Select((position, index) => new { Value = position, index })
				.GroupJoin(positionsBefore.Select((position, index) => new { Id = position.Id, index }),
					after => after.Value.Id,
					before => before.Id,
					(after, beforeGroup) => new { after, beforeGroup })
				.SelectMany(
					g => g.beforeGroup.DefaultIfEmpty(),
					(g, before) => new DriverPositionAfterRace()
					{
						Id = g.after.Value.Id,
						Driver = g.after.Value.Driver,
						NotCountedTowardsChampionshipPoints = g.after.Value.NotCountedTowardsChampionshipPoints,
						Points = g.after.Value.Points,
						Position = g.after.index + 1,
						Change = before == null ? 0 : (before.index + 1) - (g.after.index + 1)
					})
				.OrderBy(c => c.Position)
				.ToList();
			return positionsAfter;
		}
	}
}
