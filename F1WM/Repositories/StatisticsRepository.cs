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
			var fromFastestLaps = await context.FastestLaps
				.Where(f => f.Entry.DriverId == driverId && f.PositionOrStatus == "1")
				.Where(f => f.Race.Date.Year <= atYear)
				.GroupBy(f => f.Race.SeasonId)
				.Select(g => new { SeasonId = g.Key, FastestLaps = g.Count() })
				.ToListAsync();
			var fromResults = await context.Results
				.Where(r => r.Entry.DriverId == driverId)
				.Where(r => r.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new
				{
					SeasonId = g.Key,
					Wins = g.Count(r => r.PositionOrStatus == "1"),
					Podiums = g.Count(r => r.PositionOrStatus.OnPodium()),
					NotClassified = g.Count(r => r.PositionOrStatus.NotClassified())
				})
				.ToListAsync();
			var fromGrids = await context.Grids
				.Where(g => g.Entry.DriverId == driverId)
				.Where(g => g.Race.Date.Year <= atYear)
				.GroupBy(r => r.Race.SeasonId)
				.Select(g => new
				{
					SeasonId = g.Key,
					PolePositions = g.Count(gr => gr.StartPositionOrStatus == "1"),
					Starts = g.Count(gr => gr.StartPositionOrStatus.Started())
				})
				.ToListAsync();
			apiStatistics.Seasons = await mapper.ProjectTo<DriverSeason>(context.Seasons
					.Where(s => s.Year <= atYear)
					.Where(s => s.Races.SelectMany(r => r.Entries).Any(e => e.DriverId == driverId)))
				.ToListAsync();
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
			}
			return apiStatistics;
		}

		public StatisticsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}
	}
}
