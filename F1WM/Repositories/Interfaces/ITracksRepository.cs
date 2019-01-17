using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ITracksRepository
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int beforeYear);
	}
}
