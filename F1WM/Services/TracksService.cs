using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Utilities;

namespace F1WM.Services
{
	public class TracksService : ITracksService
	{
		private readonly ITracksRepository repository;
		private readonly ITimeService time;

		public Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int? beforeYear)
		{
			var now = time.Now;
			return repository.GetTrackRecords(trackId, trackVersion, beforeYear ?? now.Year);
		}

		public Task<PagedResult<TrackSummary>> GetTracks(uint page, uint countPerPage)
		{
			return repository.GetTracks(page, countPerPage);
		}

		public Task<PagedResult<TrackSummary>> GetTracksByStatusId(byte statusId, uint page, uint countPerPage)
		{
			return repository.GetTracksByStatusId(statusId, page, countPerPage);
		}

		public TracksService(ITracksRepository repository, ITimeService time)
		{
			this.time = time;
			this.repository = repository;
		}
	}
}
