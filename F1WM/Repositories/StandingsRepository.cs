using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;
using F1WM.Utilities;
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
				.Include(r => r.Entries)
				.Select(r => new
				{
					r.SeasonId,
					r.Date,
					IsFirst = r.OrderInSeason == 1,
					HasResults = r.Entries.Any()
				})
				.SingleOrDefault();
			if (constraints != null && constraints.HasResults)
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
				.Include(r => r.Entries)
				.Select(r => new
				{
					r.SeasonId,
					r.Date,
					IsFirst = r.OrderInSeason == 1,
					HasResults = r.Entries.Any()
				})
				.SingleOrDefaultAsync();
			if (constraints != null && constraints.HasResults)
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
			var tieResolutionOptions = new TieResolutionOptions
			{
				SeasonId = constraints.SeasonId,
				BeforeDate = constraints.Date,
				IdPredicateFactory = ids => r => ids.Contains(r.Entry.TeamId),
				PositionSelector = r => new RacePosition { Id = r.Entry.TeamId, Position = r.PositionOrStatus }
			};
			var positionsAfter = (await context.ConstructorPoints
					.Where(p => p.SeasonId == constraints.SeasonId && p.Race.Date <= constraints.Date)
					.Include(p => p.Constructor).ThenInclude(c => c.Nationality)
					.Select(p => new { p, p.Constructor })
					.ToListAsync())
				.GroupBy(g => g.p.ConstructorId, (key, result) => new ConstructorPositionAfterRace()
				{
					Id = key,
					Constructor = mapper.Map<ConstructorSummary>(result.FirstOrDefault().Constructor),
					NotCountedTowardsChampionshipPoints = result.Sum(p => p.p.NotCountedTowardsChampionshipPoints ?? 0),
					Points = result.Sum(p => p.p.Points ?? 0)
				})
				.OrderByDescending(p => p.Points)
				.ThenBy(p => p.Id)
				.ToList();

			positionsAfter = await ResolveTies(positionsAfter, tieResolutionOptions);

			var positionsBefore = (await context.ConstructorPoints
					.Where(c => !constraints.IsFirst)
					.Where(c => c.SeasonId == constraints.SeasonId && c.Race.Date < constraints.Date)
					.ToListAsync())
				.GroupBy(c => c.ConstructorId, (key, result) => new StandingsPosition
				{
					Id = key,
					Points = result.Sum(c => c.Points ?? 0)
				})
				.OrderByDescending(c => c.Points)
				.ThenBy(c => c.Id)
				.ToList();

			positionsBefore = await ResolveTies(positionsBefore, tieResolutionOptions);
			
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
				.ThenBy(c => c.Id)
				.ToList();
			return positionsAfter;
		}

		private async Task<IEnumerable<DriverPositionAfterRace>> GetDriversStandingsAfterRace(
			(uint SeasonId, DateTime Date, bool IsFirst) constraints)
		{
			var tieResolutionOptions = new TieResolutionOptions
			{
				SeasonId = constraints.SeasonId,
				BeforeDate = constraints.Date,
				IdPredicateFactory = ids => r => ids.Contains(r.Entry.DriverId),
				PositionSelector = r => new RacePosition { Id = r.Entry.DriverId, Position = r.PositionOrStatus }
			};
			var positionsAfter = (await context.DriverPoints
					.Where(p => p.SeasonId == constraints.SeasonId && p.Race.Date <= constraints.Date)
					.Include(p => p.Driver).ThenInclude(d => d.Nationality)
					.Select(p => new { p, p.Driver })
					.ToListAsync())
				.GroupBy(g => g.p.DriverId, (key, result) => new DriverPositionAfterRace()
				{
					Id = key,
					Driver = mapper.Map<DriverSummary>(result.FirstOrDefault().Driver),
					NotCountedTowardsChampionshipPoints = result.Sum(p => p.p.NotCountedTowardsChampionshipPoints ?? 0),
					Points = result.Sum(p => p.p.Points ?? 0)
				})
				.OrderByDescending(p => p.Points)
				.ThenBy(p => p.Id)
				.ToList();
			positionsAfter = await ResolveTies(positionsAfter, tieResolutionOptions);

			var positionsBefore = (await context.DriverPoints
					.Where(c => !constraints.IsFirst)
					.Where(c => c.SeasonId == constraints.SeasonId && c.Race.Date < constraints.Date)
					.ToListAsync())
				.GroupBy(c => c.DriverId, (key, result) => new StandingsPosition
				{
					Id = key,
					Points = result.Sum(c => c.Points ?? 0)
				})
				.OrderByDescending(c => c.Points)
				.ThenBy(c => c.Id)
				.ToList();

			positionsBefore = await ResolveTies(positionsBefore, tieResolutionOptions);

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

		private async Task<List<T>> ResolveTies<T>(List<T> positions, TieResolutionOptions options)
			where T : IStandingsPosition
		{
			var tiedStandingsPositionsGroups = positions
				.Where(p => p.Points > 0)
				.GroupBy(p => p.Points)
				.Where(group => group.Count() > 1)
				.ToList();

			foreach (var tiedPositionsGroup in tiedStandingsPositionsGroups)
			{
				var idPredicate = options.IdPredicateFactory(tiedPositionsGroup.Select(g => g.Id));
				var racePositionsCounts = (await context.Results
						.Where(r => r.Race.SeasonId == options.SeasonId && r.Race.Date <= options.BeforeDate)
						.Where(r => !string.IsNullOrEmpty(r.PositionOrStatus))
						.Where(idPredicate)
						.Select(options.PositionSelector)
						.ToListAsync())
					.GroupBy(r => r.Id)
					.Select(group => new
					{
						Id = group.Key,
						PositionsCounts = CountPositions(group)
					})
					.OrderByDescending(p => p.PositionsCounts, new PositionsCountsComparer())
					.ThenBy(p => p.Id);

				var tieIndex = positions.TakeWhile(p => p.Points != tiedPositionsGroup.Key).Count();
				var sortedPositionsToInsert = racePositionsCounts.Select(c => positions.Single(p => p.Id == c.Id)).ToList();
				positions.RemoveRange(tieIndex, racePositionsCounts.Count());
				positions.InsertRange(tieIndex, sortedPositionsToInsert);
			}
			return positions;
		}

		private PositionsCounts CountPositions(IGrouping<uint, RacePosition> groupedRacePositions)
		{
			return groupedRacePositions.Aggregate(new PositionsCounts(), (all, result) =>
			{
				if (int.TryParse(result.Position, out var position))
				{
					if (all.Positions.ContainsKey(position))
					{
						all.Positions[position]++;
					}
					else
					{
						all.Positions.Add(position, 1);
					}
				}
				return all;
			});
		}
	}
}
