using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public class BroadcastsService : IBroadcastsService
	{
		public Task<BroadcastsInformation> AddBroadcast(BroadcastsAddRequest request)
		{
			throw new System.NotImplementedException();
		}

		public Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			throw new System.NotImplementedException();
		}

		public Task<BroadcastsInformation> GetNextBroadcasts()
		{
			throw new System.NotImplementedException();
		}
	}
}