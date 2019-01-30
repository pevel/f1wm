using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ITracksService
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int? beforeYear);
		Task<PagedResult<TrackSummary>> GetTracks(int page, int countPerPage);
		Task<PagedResult<TrackSummary>> GetTracksByStatusId(byte statusId, int page, int countPerPage);
	}
}
