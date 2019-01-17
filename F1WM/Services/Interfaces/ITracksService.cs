using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ITracksService
	{
		Task<TrackRecordsInformation> GetTrackRecords(int trackId, int trackVersion, int? beforeYear);
	}
}