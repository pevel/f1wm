using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class BroadcastsService : IBroadcastsService
	{
		private readonly IBroadcastsRepository repository;
		private readonly ITimeService time;

		public Task<BroadcastsInformation> AddBroadcast(BroadcastsAddRequest request)
		{
			return repository.AddBroadcast(request);
		}

		public Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request)
		{
			return repository.AddBroadcaster(request);
		}

		public async Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			var broadcasters = await repository.GetBroadcasters();
			broadcasters.ToList().ForEach(b => b.Broadcasts = null);
			return broadcasters;
		}

		public Task<BroadcastsInformation> GetNextBroadcasts()
		{
			return repository.GetBroadcastsAfter(time.Now);
		}

		public Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return repository.GetSessionNames();
		}

		public Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request)
		{
			return repository.AddSessionName(request);
		}

		public BroadcastsService(IBroadcastsRepository repository, ITimeService time)
		{
			this.repository = repository;
			this.time = time;
		}
	}
}
