using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class TracksService : ITracksService
	{
		private readonly ITracksRepository repository;
		private readonly ITimeService time;

		public Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int? beforeYear)
		{
			var now = time.Now;
			return repository.GetTrackRecords(trackId, trackVersion, beforeYear.HasValue ? beforeYear.Value : now.Year);
		}

		public TracksService(ITracksRepository repository, ITimeService time)
		{
			this.time = time;
			this.repository = repository;
		}
	}
}
