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
			return await context.Entries
				.Where(e => e.DriverId == driverId)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					Team = e.Team
				})
				.GroupBy(e => new { e.SeasonId, e.Team.Id })
				.Select(e => new TeamsSeason
				{
					SeasonId = e.Key.SeasonId,
					Team = mapper.Map<TeamSummary>(e.Select(g => g.Team).First())
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<DriversSeason>> GetDrivers(
			Expression<Func<Entry, bool>> selector,
			int atYear)
		{
			return await context.Entries
				.Where(selector)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					TeamId = e.TeamId,
					Driver = e.Driver
				})
				.GroupBy(e => new { e.SeasonId, e.TeamId, e.Driver.Id })
				.Select(g => new DriversSeason
				{
					SeasonId = g.Key.SeasonId,
					Driver = mapper.Map<DriverSummary>(g.Select(entry => entry.Driver).FirstOrDefault())
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<CarsSeason>> GetCars(
			Expression<Func<Entry, bool>> selector,
			int atYear)
		{
			return await context.Entries
				.Where(selector)
				.Where(e => e.Race.Date.Year <= atYear)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					TeamId = e.TeamId,
					Car = e.Car
				})
				.GroupBy(e => new { e.SeasonId, e.TeamId, e.Car.Id })
				.Select(g => new CarsSeason
				{
					SeasonId = g.Key.SeasonId,
					Car = mapper.Map<CarSummary>(g.Select(entry => entry.Car).FirstOrDefault())
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<PointsStatistics>> GetPointsStatistics(
			Expression<Func<DriverPoints, bool>> selector,
			int atYear)
		{
			return await context.DriverPoints
				.Where(selector)
				.Where(p => p.Race.Date.Year <= atYear)
				.GroupBy(p => p.SeasonId)
				.Select(g => new PointsStatistics
				{
					SeasonId = g.Key,
					Points = g.Sum(p => p.Points ?? 0) + g.Sum(p => p.NotCountedTowardsChampionshipPoints ?? 0),
					AnyPoints = g.Count()
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<GridStatistics>> GetGridStatistics(
			Expression<Func<Grid, bool>> selector,
			int atYear)
		{
			return await context.Grids
				.Where(selector)
				.Where(g => g.Race.Date.Year <= atYear)
				.Where(g => g.Entry.Result.PositionOrStatus != DatabaseConstants.ResultStatus.DidNotStart)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new GridStatistics
				{
					SeasonId = g.Key,
					PolePositions = g.Count(grid => grid.StartPositionOrStatus == "1"),
					GrandPrixCount = g.GroupBy(grid => grid.RaceId)
						.Count(raceGrids => raceGrids.Any(raceGrid => raceGrid.Started())),
					Starts = g.Count(grid => grid.Started())
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ResultsStatistics>> GetResultsStatistics(
			Expression<Func<Result, bool>> selector,
			int atYear)
		{
			return await context.Results
				.Where(selector)
				.Where(r => r.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new ResultsStatistics
				{
					SeasonId = g.Key,
					Wins = g.Count(r => r.PositionOrStatus == "1"),
					Podiums = g.Count(r => r.PositionOrStatus.OnPodium()),
					NotFinished = g.Count(r => r.PositionOrStatus.NotFinished()),
					NotClassified = g.Count(r => r.PositionOrStatus.NotClassified())
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<FastestLapsStatistics>> GetFastestLapsStatistics(
			Expression<Func<FastestLap, bool>> selector,
			 int atYear)
		{
			return await context.FastestLaps
				.Where(selector)
				.Where(f => f.PositionOrStatus == "1" && f.Race.Date.Year <= atYear)
				.GroupBy(f => f.Race.SeasonId)
				.Select(g => new FastestLapsStatistics { SeasonId = g.Key, FastestLaps = g.Count() })
				.ToListAsync();
		}

		public CommonStatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
