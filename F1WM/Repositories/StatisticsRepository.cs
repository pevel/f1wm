using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Repositories.Statistics;
using F1WM.Repositories.Statistics.Model;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class StatisticsRepository : RepositoryBase, IStatisticsRepository
	{
		private readonly IMapper mapper;
		private readonly CommonStatisticsRepository common;

		public async Task<DriverStatistics> GetDriverStatistics(int driverId, int atYear)
		{
			var apiStatistics = new DriverStatistics() { DriverId = driverId };
			var fromFastestLaps = await common.GetFastestLapsStatistics(f => f.Entry.DriverId == driverId, atYear);
			var fromResults = await common.GetResultsStatistics(r => r.Entry.DriverId == driverId, atYear);
			var fromGrids = await common.GetGridStatistics(g => g.Entry.DriverId == driverId, atYear);
			var fromPoints = await common.GetPointsStatistics(p => p.DriverId == driverId, atYear);
			var teams = await common.GetTeams(driverId, atYear);
			await IncludeDriverSeasons(driverId, atYear, apiStatistics);
			FillDriverSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints, teams);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public async Task<TeamStatistics> GetTeamStatistics(int teamId, int atYear)
		{
			var apiStatistics = new TeamStatistics() { TeamId = teamId };
			var fromFastestLaps = await common.GetFastestLapsStatistics(f => f.Entry.TeamId == teamId, atYear);
			var fromResults = await common.GetResultsStatistics(r => r.Entry.TeamId == teamId, atYear);
			var fromGrids = await common.GetGridStatistics(g => g.Entry.TeamId == teamId, atYear);
			var fromPoints = await common.GetPointsStatistics(p => p.Entry.TeamId == teamId, atYear);
			var cars = await common.GetCars(e => e.TeamId == teamId, atYear);
			var drivers = await common.GetDrivers(e => e.TeamId == teamId, atYear);
			await IncludeTeamSeasons(teamId, atYear, apiStatistics);
			FillTeamSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints, cars, drivers);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public async Task<EngineStatistics> GetEngineStatistics(int engineId, int atYear)
		{
			var apiStatistics = new EngineStatistics() { EngineId = engineId };
			var fromFastestLaps = await common.GetFastestLapsStatistics(f => f.Entry.EngineId == engineId, atYear);
			var fromResults = await common.GetResultsStatistics(r => r.Entry.EngineId == engineId, atYear);
			var fromGrids = await common.GetGridStatistics(g => g.Entry.EngineId == engineId, atYear);
			var fromPoints = await common.GetPointsStatistics(p => p.Entry.EngineId == engineId, atYear);
			var cars = await common.GetCars(e => e.EngineId == engineId, atYear);
			var drivers = await common.GetDrivers(e => e.EngineId == engineId, atYear);
			await IncludeEngineSeasons(engineId, atYear, apiStatistics);
			FillEngineSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints, cars, drivers);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public StatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
			this.common = new CommonStatisticsRepository(context, mapper);
		}

		private static void FillDriverSeasons(
			DriverStatistics apiStatistics,
			IEnumerable<FastestLapsStatistics> fromFastestLaps,
			IEnumerable<ResultsStatistics> fromResults,
			IEnumerable<GridStatistics> fromGrids,
			IEnumerable<PointsStatistics> fromPoints,
			IEnumerable<TeamsSeason> teams)
		{
			foreach (var s in apiStatistics.Seasons)
			{
				s.FastestLaps = fromFastestLaps
					.Where(f => f.SeasonId == s.Season.Id)
					.Select(f => f.FastestLaps)
					.FirstOrDefault();
				(s.NotClassified, s.Podiums, s.Wins) = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => (r.NotClassified, r.Podiums, r.Wins))
					.FirstOrDefault();
				(s.Starts, s.PolePositions) = fromGrids
					.Where(g => g.SeasonId == s.Season.Id)
					.Select(g => (g.Starts, g.PolePositions))
					.FirstOrDefault();
				(s.Points, s.AnyPoints) = fromPoints
					.Where(p => p.SeasonId == s.Season.Id)
					.Select(p => (p.Points, p.AnyPoints))
					.FirstOrDefault();
				s.Teams = teams
					.Where(t => t.SeasonId == s.Season.Id)
					.Select(t => t.Team);
			}
		}

		private void FillTeamSeasons(
			TeamStatistics apiStatistics,
			IEnumerable<FastestLapsStatistics> fromFastestLaps,
			IEnumerable<ResultsStatistics> fromResults,
			IEnumerable<GridStatistics> fromGrids,
			IEnumerable<PointsStatistics> fromPoints,
			IEnumerable<CarsSeason> cars,
			IEnumerable<DriversSeason> drivers)
		{
			foreach (var s in apiStatistics.Seasons)
			{
				s.FastestLaps = fromFastestLaps
					.Where(f => f.SeasonId == s.Season.Id)
					.Select(f => f.FastestLaps)
					.FirstOrDefault();
				(s.NotFinished, s.Podiums, s.Wins) = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => (r.NotFinished, r.Podiums, r.Wins))
					.FirstOrDefault();
				(s.Starts, s.GrandPrixCount, s.PolePositions) = fromGrids
					.Where(g => g.SeasonId == s.Season.Id)
					.Select(g => (g.Starts, g.GrandPrixCount, g.PolePositions))
					.FirstOrDefault();
				s.Points = fromPoints
					.Where(p => p.SeasonId == s.Season.Id)
					.Select(p => p.Points)
					.FirstOrDefault();
				s.Cars = cars
					.Where(c => c.SeasonId == s.Season.Id)
					.Select(c => c.Car);
				s.Drivers = drivers
					.Where(d => d.SeasonId == s.Season.Id)
					.Select(d => d.Driver);
			}
		}

		private void FillEngineSeasons(
			EngineStatistics apiStatistics,
			IEnumerable<FastestLapsStatistics> fromFastestLaps,
			IEnumerable<ResultsStatistics> fromResults,
			IEnumerable<GridStatistics> fromGrids,
			IEnumerable<PointsStatistics> fromPoints,
			IEnumerable<CarsSeason> cars,
			IEnumerable<DriversSeason> drivers)
		{
			foreach (var s in apiStatistics.Seasons)
			{
				s.FastestLaps = fromFastestLaps
					.Where(f => f.SeasonId == s.Season.Id)
					.Select(f => f.FastestLaps)
					.FirstOrDefault();
				(s.NotFinished, s.Podiums, s.Wins) = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => (r.NotFinished, r.Podiums, r.Wins))
					.FirstOrDefault();
				(s.Starts, s.GrandPrixCount, s.PolePositions) = fromGrids
					.Where(g => g.SeasonId == s.Season.Id)
					.Select(g => (g.Starts, g.GrandPrixCount, g.PolePositions))
					.FirstOrDefault();
				s.Points = fromPoints
					.Where(p => p.SeasonId == s.Season.Id)
					.Select(p => p.Points)
					.FirstOrDefault();
				s.Cars = cars
					.Where(c => c.SeasonId == s.Season.Id)
					.Select(c => c.Car);
				s.Drivers = drivers
					.Where(d => d.SeasonId == s.Season.Id)
					.Select(d => d.Driver);
			}
		}

		private async Task IncludeDriverSeasons(int driverId, int atYear, DriverStatistics apiStatistics)
		{
			var dbSeasons = await context.Seasons
					.Include(s => s.DriverStandings)
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.DriverId == driverId))
					.OrderByDescending(s => s.Year)
					.ToListAsync();
			apiStatistics.Seasons = dbSeasons
				.Select(s => new DriverSeason
				{
					Season = mapper.Map<SeasonSummary>(s),
					Position = s.DriverStandings
						.Where(ds => ds.DriverId == driverId)
						.Select(ds => ds.Position == 0 ? null : (ushort?)ds.Position)
						.FirstOrDefault()
				})
				.ToList();
		}

		private async Task IncludeTeamSeasons(int teamId, int atYear, TeamStatistics apiStatistics)
		{
			apiStatistics.Seasons = await mapper.ProjectTo<TeamSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.TeamId == teamId))
					.OrderByDescending(s => s.Year))
				.ToListAsync();
		}

		private async Task IncludeEngineSeasons(int engineId, int atYear, EngineStatistics apiStatistics)
		{
			apiStatistics.Seasons = await mapper.ProjectTo<EngineSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.EngineId == engineId))
					.OrderByDescending(s => s.Year))
				.ToListAsync();
		}
	}
}
