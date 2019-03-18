using System;
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

		public Task<BroadcastsInformation> AddBroadcasts(BroadcastsAddRequest request)
		{
			return repository.AddBroadcasts(request);
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

		public Task<BroadcastsInformation> GetNextBroadcasts(DateTime? after = null)
		{
			after = after ?? time.Now;
			return repository.GetBroadcastsAfter(after.Value);
		}

		public Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return repository.GetSessionTypes();
		}

		public Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request)
		{
			return repository.AddSessionType(request);
		}

		public BroadcastsService(IBroadcastsRepository repository, ITimeService time)
		{
			this.repository = repository;
			this.time = time;
		}
	}
}
