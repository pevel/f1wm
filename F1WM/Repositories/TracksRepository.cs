using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using AutoMapper;
using System.Linq.Expressions;

namespace F1WM.Repositories
{
	public class TracksRepository : RepositoryBase, ITracksRepository
	{
		private readonly IMapper mapper;
		private readonly Expression<Func<Qualifying, bool>> hasFastestLap = q => q.Session1Position == 1 || q.Session2Position == 1 || q.Session3Position == 1 || (q.Session1Position == 0 && q.PositionOrStatus == "1");

		public async Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear)
		{
			var dbFastestQualifyingLap = (await context.Qualifying
				.Include(q => q.Race)
				.Include(q => q.Entry).ThenInclude(e => e.Driver)
				.Include(q => q.Entry).ThenInclude(e => e.Car)
				.Where(hasFastestLap)
				.Where(q => q.Race.Date.Year < beforeYear)
				.Where(q => q.Race.TrackId == trackId && q.Race.TrackVersion == trackVersion)
				.Select(q => new { Qualifying = q, Time = (new [] { q.Session1Time, q.Session2Time, q.Session3Time }).Where(t => t != TimeSpan.Zero).Min() })
				.OrderBy(g => g.Time)
				.FirstOrDefaultAsync())
				?.Qualifying;
			var dbBestAverageSpeedResult = await context.Results
				.Include(r => r.Race).ThenInclude(r => r.Track)
				.Include(f => f.Entry).ThenInclude(e => e.Driver)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Where(r => r.Race.TrackId == trackId && r.Race.TrackVersion == trackVersion)
				.Where(r => r.Race.Date.Year < beforeYear)
				.Where(r => r.FinishedLaps == r.Race.Laps)
				.OrderBy(r => r.Time)
				.FirstOrDefaultAsync(r => r.Time != TimeSpan.Zero);
			var dbFastestLap = await context.FastestLaps
				.Include(f => f.Race)
				.Include(f => f.Entry).ThenInclude(e => e.Driver)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Where(f => f.Race.TrackId == trackId && f.Race.TrackVersion == trackVersion)
				.Where(f => f.Race.Date.Year < beforeYear)
				.Where(f => f.Frlpos == "1")
				.OrderBy(f => f.Time)
				.FirstOrDefaultAsync();
			if (dbFastestQualifyingLap == null && dbBestAverageSpeedResult == null && dbFastestLap == null)
			{
				return null;
			}
			else
			{
				return new TrackRecordsInformation()
				{
					TrackId = trackId,
					TrackVersion = trackVersion,
					BeforeYear = beforeYear,
					FastestQualifyingLapResult = mapper.Map<FastestQualifyingLapResultSummary>(dbFastestQualifyingLap),
					FastestRaceLapResult = mapper.Map<FastestLapResultSummary>(dbFastestLap),
					BestAverageSpeedResult = mapper.Map<AverageSpeedResult>(dbBestAverageSpeedResult)
				};
			}
		}

		public TracksRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}
	}
}
