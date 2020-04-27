using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Repositories.Statistics.Model;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;
using DatabaseConstants = F1WM.DatabaseModel.Constants;

namespace F1WM.Repositories.Statistics
{
	public class CommonStatisticsRepository : RepositoryBase
	{
		private readonly IMapper mapper;

		public async Task<IEnumerable<TeamsSeason>> GetTeams(int driverId, int atYear)
		{
			return (await context.Entries
				.Where(e => e.DriverId == driverId)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					Team = e.Team
				})
				.ToListAsync())
				.GroupBy(e => new { e.SeasonId, e.Team.Id })
				.Select(e => new TeamsSeason
				{
					SeasonId = e.Key.SeasonId,
					Team = mapper.Map<TeamSummary>(e.Select(g => g.Team).First())
				});
		}

		public async Task<IEnumerable<DriversSeason>> GetDrivers(
			Expression<Func<Entry, bool>> selector,
			int atYear)
		{
			return (await context.Entries
				.Where(selector)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					TeamId = e.TeamId,
					Driver = e.Driver
				})
				.ToListAsync())
				.GroupBy(e => new { e.SeasonId, e.TeamId, e.Driver.Id })
				.Select(g => new DriversSeason
				{
					SeasonId = g.Key.SeasonId,
					Driver = mapper.Map<DriverSummary>(g.Select(entry => entry.Driver).FirstOrDefault())
				});
		}

		public async Task<IEnumerable<CarsSeason>> GetCars(
			Expression<Func<Entry, bool>> selector,
			int atYear)
		{
			return (await context.Entries
				.Where(selector)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					TeamId = e.TeamId,
					Car = e.Car
				})
				.ToListAsync())
				.GroupBy(e => new { e.SeasonId, e.TeamId, e.Car.Id })
				.Select(g => new CarsSeason
				{
					SeasonId = g.Key.SeasonId,
					Car = mapper.Map<CarSummary>(g.Select(entry => entry.Car).FirstOrDefault())
				});
		}

		public async Task<IEnumerable<PointsStatistics>> GetPointsStatistics(
			Expression<Func<DriverPoints, bool>> selector,
			int atYear)
		{
			return (await context.DriverPoints
				.Where(selector)
				.Where(p => p.Race.Date.Year <= atYear)
				.ToListAsync())
				.GroupBy(p => p.SeasonId)
				.Select(g => new PointsStatistics
				{
					SeasonId = g.Key,
					Points = g.Sum(p => p.Points ?? 0) + g.Sum(p => p.NotCountedTowardsChampionshipPoints ?? 0),
					AnyPoints = g.Count()
				});
		}

		public async Task<IEnumerable<GridStatistics>> GetGridStatistics(
			Expression<Func<Grid, bool>> selector,
			int atYear)
		{
			return (await context.Grids
				.Where(selector)
				.Where(g => g.Race.Date.Year <= atYear)
				.Where(g => g.Entry.Result.PositionOrStatus != DatabaseConstants.ResultStatus.DidNotStart)
				.Select(g => new {
					Grid = g,
					SeasonId = g.Race.SeasonId
				})
				.ToListAsync())
				.GroupBy(g => g.SeasonId)
				.Select(group => new GridStatistics
				{
					SeasonId = group.Key,
					PolePositions = group.Count(g => g.Grid.StartPositionOrStatus == "1"),
					GrandPrixCount = group.GroupBy(g => g.Grid.RaceId)
						.Count(raceGrids => raceGrids.Any(raceGrid => raceGrid.Grid.Started())),
					Starts = group.Count(grid => grid.Grid.Started())
				});
		}

		public async Task<IEnumerable<ResultsStatistics>> GetResultsStatistics(
			Expression<Func<Result, bool>> selector,
			int atYear)
		{
			return (await context.Results
				.Where(selector)
				.Where(r => r.Race.Date.Year <= atYear)
				.Select(r => new {
					Result = r,
					SeasonId = r.Race.SeasonId
				})
				.ToListAsync())
				.GroupBy(r => r.SeasonId)
				.Select(group => new ResultsStatistics
				{
					SeasonId = group.Key,
					Wins = group.Count(r => r.Result.PositionOrStatus == "1"),
					Podiums = group.Count(r => r.Result.PositionOrStatus.OnPodium()),
					NotFinished = group.Count(r => r.Result.PositionOrStatus.NotFinished()),
					NotClassified = group.Count(r => r.Result.PositionOrStatus.NotClassified())
				});				
		}

		public async Task<IEnumerable<FastestLapsStatistics>> GetFastestLapsStatistics(
			Expression<Func<FastestLap, bool>> selector,
			 int atYear)
		{
			return (await context.FastestLaps
				.Where(selector)
				.Where(f => f.PositionOrStatus == "1" && f.Race.Date.Year <= atYear)
				.Select(f => new { SeasonId = f.Race.SeasonId })
				.ToListAsync())
				.GroupBy(f => f.SeasonId)
				.Select(group => new FastestLapsStatistics { SeasonId = group.Key, FastestLaps = group.Count() });
		}

		public CommonStatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
