using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ITracksRepository
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear);
		Task<PagedResult<Track>> GetTracks(uint page, uint countPerPage);
		Task<PagedResult<Track>> GetTracksByStatus(byte statusId, uint page, uint countPerPage);
		Task<TrackDetails> GetTrack(int id, int atYear);
	}
}
