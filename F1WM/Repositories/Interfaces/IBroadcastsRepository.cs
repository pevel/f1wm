using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IBroadcastsRepository
	{
		Task<BroadcastsInformation> AddBroadcast(BroadcastsAddRequest request);
		Task<ApiModel.Broadcaster> AddBroadcaster(BroadcasterAddRequest request);
		Task<IEnumerable<ApiModel.Broadcaster>> GetBroadcasters();
		Task<BroadcastsInformation> GetBroadcastsAfter(DateTime now);
	}
}