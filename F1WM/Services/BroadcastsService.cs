using System.Collections.Generic;
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

		public Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			return repository.GetBroadcasters();
		}

		public Task<BroadcastsInformation> GetNextBroadcasts()
		{
			return repository.GetBroadcastsAfter(time.Now);
		}

		public Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return repository.GetSessionNames();
		}

		public Task<BroadcastSessionType> AddSessionType(BroadcastSessionType name)
		{
			return repository.AddSessionName(name);
		}

		public BroadcastsService(IBroadcastsRepository repository, ITimeService time)
		{
			this.repository = repository;
			this.time = time;
		}
	}
}
