using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IBroadcastsService
	{
		Task<BroadcastsInformation> GetNextBroadcasts();
		Task<IEnumerable<Broadcaster>> GetBroadcasters();
		Task<BroadcastsInformation> AddBroadcast(BroadcastsAddRequest request);
		Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request);
		Task<IEnumerable<BroadcastSessionType>> GetSessionTypes();
		Task<BroadcastSessionType> AddSessionType(BroadcastSessionType name);
	}
}
