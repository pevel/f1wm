using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class StatisticsRepository : RepositoryBase, IStatisticsRepository
	{
		private readonly IMapper mapper;

		public async Task<DriverStatistics> GetDriverStatistics(int driverId, int atYear)
		{
			var apiStatistics = new DriverStatistics() { DriverId = driverId };
			var fromFastestLaps = await GetFastestLapsStatistics(f => f.Entry.DriverId == driverId,	atYear);
			var fromResults = await GetResultsStatistics(r => r.Entry.DriverId == driverId, atYear);
			var fromGrids = await GetGridStatistics(g => g.Entry.DriverId == driverId, atYear);
			var fromPoints = await GetPointsStatistics(p => p.DriverId == driverId, atYear);
			var teams = await GetTeams(driverId);
			await IncludeDriverSeasons(driverId, atYear, apiStatistics);
			FillDriverSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints, teams);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public async Task<TeamStatistics> GetTeamStatistics(int teamId, int atYear)
		{
			var apiStatistics = new TeamStatistics() { TeamId = teamId };
			var fromFastestLaps = await GetFastestLapsStatistics(f => f.Entry.TeamId == teamId, atYear);
			var fromResults = await GetResultsStatistics(r => r.Entry.TeamId == teamId, atYear);
			var fromGrids = await GetGridStatistics(g => g.Entry.TeamId == teamId, atYear);
			var fromPoints = await GetPointsStatistics(p => p.Entry.TeamId == teamId, atYear);
			await IncludeTeamSeasons(teamId, atYear, apiStatistics);
			FillTeamSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public StatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}

		private static void FillDriverSeasons(
			DriverStatistics apiStatistics,
			IEnumerable<FastestLapsStatistics> fromFastestLaps,
			IEnumerable<ResultsStatistics> fromResults,
			IEnumerable<GridStatistics> fromGrids,
			IEnumerable<PointsStatistics> fromPoints,
			IEnumerable<Teams> teams)
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
					.Select(g => (g.GrandPrixCount, g.PolePositions))
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
			IEnumerable<PointsStatistics> fromPoints)
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
			}
		}

		private async Task<IEnumerable<Teams>> GetTeams(int driverId)
		{
			return await context.Entries
				.Where(e => e.DriverId == driverId)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					Team = e.Team
				})
				.GroupBy(e => new { e.SeasonId, e.Team.Id })
				.Select(e => new Teams
				{
					SeasonId = e.Key.SeasonId,
					Team = mapper.Map<TeamSummary>(e.Select(g => g.Team).First())
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<PointsStatistics>> GetPointsStatistics(
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

		private async Task<IEnumerable<GridStatistics>> GetGridStatistics(
			Expression<Func<Grid, bool>> selector,
			int atYear)
		{
			return await context.Grids
				.Where(selector)
				.Where(g => g.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new GridStatistics
				{
					SeasonId = g.Key,
					PolePositions = g.Count(grid => grid.StartPositionOrStatus == "1"),
					GrandPrixCount = g.GroupBy(grid => grid.RaceId)
						.Count(raceGrids => raceGrids.Any(raceGrid => raceGrid.StartPositionOrStatus.Started())),
					Starts = g.Count(grid => grid.StartPositionOrStatus.Started())
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<ResultsStatistics>> GetResultsStatistics(
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

		private async Task<IEnumerable<FastestLapsStatistics>> GetFastestLapsStatistics(
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

		private async Task IncludeDriverSeasons(int driverId, int atYear, DriverStatistics apiStatistics)
		{
			apiStatistics.Seasons = await mapper.ProjectTo<DriverSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.DriverId == driverId))
					.OrderByDescending(s => s.Year))
				.ToListAsync();
		}

		private async Task IncludeTeamSeasons(int teamId, int atYear, TeamStatistics apiStatistics)
		{
			apiStatistics.Seasons = await mapper.ProjectTo<TeamSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.TeamId == teamId))
					.OrderByDescending(s => s.Year))
				.ToListAsync();
		}

		private class FastestLapsStatistics
		{
			public uint SeasonId { get; set; }
			public int FastestLaps { get; set; }
		}

		private class ResultsStatistics
		{
			public uint SeasonId { get; set; }
			public int Wins { get; set; }
			public int Podiums { get; set; }
			public int NotClassified { get; set; }
			public int NotFinished { get; set; }
		}

		private class GridStatistics
		{
			public uint SeasonId { get; set; }
			public int PolePositions { get; set; }
			public int Starts { get; set; }
			public int GrandPrixCount { get; set; }
		}

		private class PointsStatistics
		{
			public uint SeasonId { get; set; }
			public float Points { get; set; }
			public int AnyPoints { get; set; }
		}

		private class Teams
		{
			public uint SeasonId { get; set; }
			public TeamSummary Team { get; set; }
		}
	}
}
