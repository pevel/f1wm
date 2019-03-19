using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IBroadcastsService
	{
		Task<BroadcastsInformation> GetNextBroadcasts(DateTime? after = null);
		Task<IEnumerable<Broadcaster>> GetBroadcasters();
		Task<BroadcastsInformation> AddBroadcasts(BroadcastsAddRequest request);
		Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request);
		Task<IEnumerable<BroadcastSessionType>> GetSessionTypes();
		Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request);
	}
}
