using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ITracksRepository
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear);
		Task<PagedResult<TrackSummary>> GetTracks(uint page, uint countPerPage);
		Task<PagedResult<TrackSummary>> GetTracksByStatusId(byte statusId, uint page, uint countPerPage);
	}
}
