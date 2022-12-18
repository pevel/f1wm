using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ITracksRepository
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear);
		Task<PagedResult<Track>> GetTracks(int page, int countPerPage);
		Task<PagedResult<Track>> GetTracksByStatus(byte statusId, int page, int countPerPage);
		Task<TrackDetails> GetTrack(int id, int atYear);
		Task<TrackShortResultsByYears> GetShortResultsByYears(int trackId, int untilYear);
	}
}
