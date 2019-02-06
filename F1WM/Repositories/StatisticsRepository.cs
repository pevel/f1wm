using System.Collections.Generic;
using System.Linq;
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
			var fromFastestLaps = await GetFastestLapsStatistics(driverId, atYear);
			var fromResults = await GetResultsStatistics(driverId, atYear);
			var fromGrids = await GetGridStatistics(driverId, atYear);
			var fromPoints = await GetPointsStatistics(driverId, atYear);
			var teams = await GetTeamsStatistics(driverId);
			await IncludeSeasons(driverId, atYear, apiStatistics);
			FillSeasons(apiStatistics, fromFastestLaps, fromResults, fromGrids, fromPoints, teams);
			return apiStatistics.Seasons.Any() ? apiStatistics : null;
		}

		public Task<TeamStatistics> GetTeamStatistics(int teamId, int v)
		{
			throw new System.NotImplementedException();
		}

		public StatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}

		private static void FillSeasons(
			DriverStatistics apiStatistics,
			IEnumerable<FastestLapsStatistics> fromFastestLaps,
			IEnumerable<ResultsStatistics> fromResults,
			IEnumerable<GridStatistics> fromGrids,
			IEnumerable<PointsStatistics> fromPoints,
			IEnumerable<TeamsStatistics> teams)
		{
			foreach (var s in apiStatistics.Seasons)
			{
				s.FastestLaps = fromFastestLaps
					.Where(f => f.SeasonId == s.Season.Id)
					.Select(f => f.FastestLaps)
					.FirstOrDefault();
				s.NotClassified = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => r.NotClassified)
					.FirstOrDefault();
				s.Podiums = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => r.Podiums)
					.FirstOrDefault();
				s.Starts = fromGrids
					.Where(g => g.SeasonId == s.Season.Id)
					.Select(g => g.Starts)
					.FirstOrDefault();
				s.PolePositions = fromGrids
					.Where(g => g.SeasonId == s.Season.Id)
					.Select(g => g.PolePositions)
					.FirstOrDefault();
				s.Wins = fromResults
					.Where(r => r.SeasonId == s.Season.Id)
					.Select(r => r.Wins)
					.FirstOrDefault();
				s.Points = fromPoints
					.Where(p => p.SeasonId == s.Season.Id)
					.Select(p => p.Points)
					.FirstOrDefault();
				s.AnyPoints = fromPoints
					.Where(p => p.SeasonId == s.Season.Id)
					.Select(p => p.AnyPoints)
					.FirstOrDefault();
				s.Teams = teams
					.Where(t => t.SeasonId == s.Season.Id)
					.Select(t => t.Team);
			}
		}

		private async Task<IEnumerable<TeamsStatistics>> GetTeamsStatistics(int driverId)
		{
			return await context.Entries
				.Where(e => e.DriverId == driverId)
				.Select(e => new
				{
					SeasonId = e.Race.SeasonId,
					Team = e.Team
				})
				.GroupBy(e => new { e.SeasonId, e.Team.Id })
				.Select(e => new TeamsStatistics
				{
					SeasonId = e.Key.SeasonId,
					Team = mapper.Map<TeamSummary>(e.Select(g => g.Team).First())
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<PointsStatistics>> GetPointsStatistics(int driverId, int atYear)
		{
			return await context.DriverPoints
				.Where(p => p.DriverId == driverId)
				.Where(p => p.Race.Date.Year <= atYear)
				.GroupBy(p => p.SeasonId)
				.Select(g => new PointsStatistics
				{
					SeasonId = g.Key,
					Points = g.Sum(p => p.Points ?? 0),
					AnyPoints = g.Count()
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<GridStatistics>> GetGridStatistics(int driverId, int atYear)
		{
			return await context.Grids
				.Where(g => g.Entry.DriverId == driverId)
				.Where(g => g.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new GridStatistics
				{
					SeasonId = g.Key,
					PolePositions = g.Count(gr => gr.StartPositionOrStatus == "1"),
					Starts = g.Count(gr => gr.StartPositionOrStatus.Started())
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<ResultsStatistics>> GetResultsStatistics(int driverId, int atYear)
		{
			return await context.Results
				.Where(r => r.Entry.DriverId == driverId)
				.Where(r => r.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new ResultsStatistics
				{
					SeasonId = g.Key,
					Wins = g.Count(r => r.PositionOrStatus == "1"),
					Podiums = g.Count(r => r.PositionOrStatus.OnPodium()),
					NotClassified = g.Count(r => r.PositionOrStatus.NotClassified())
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<FastestLapsStatistics>> GetFastestLapsStatistics(int driverId, int atYear)
		{
			return await context.FastestLaps
				.Where(f => f.Entry.DriverId == driverId && f.PositionOrStatus == "1")
				.Where(f => f.Race.Date.Year <= atYear)
				.GroupBy(f => f.Race.SeasonId)
				.Select(g => new FastestLapsStatistics { SeasonId = g.Key, FastestLaps = g.Count() })
				.ToListAsync();
		}

		private async Task IncludeSeasons(int driverId, int atYear, DriverStatistics apiStatistics)
		{
			apiStatistics.Seasons = await mapper.ProjectTo<DriverSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.DriverId == driverId)))
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
		}

		private class GridStatistics
		{
			public uint SeasonId { get; set; }
			public int PolePositions { get; set; }
			public int Starts { get; set; }
		}

		private class PointsStatistics
		{
			public uint SeasonId { get; set; }
			public float Points { get; set; }
			public int AnyPoints { get; set; }
		}

		private class TeamsStatistics
		{
			public uint SeasonId { get; set; }
			public TeamSummary Team { get; set; }
		}
	}
}
