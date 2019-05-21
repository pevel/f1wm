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
		private readonly IBroadcastsRepository broadcastsRepository;
		private readonly ISeasonsRepository seasonsRepository;
		private readonly ITimeService time;

		public Task<BroadcastsInformation> AddBroadcasts(BroadcastsAddRequest request)
		{
			return broadcastsRepository.AddBroadcasts(request);
		}

		public Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request)
		{
			return broadcastsRepository.AddBroadcaster(request);
		}

		public async Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			var broadcasters = await broadcastsRepository.GetBroadcasters();
			broadcasters.ToList().ForEach(b => b.Broadcasts = null);
			return broadcasters;
		}

		public async Task<BroadcastsInformation> GetNextBroadcasts(DateTime? after = null)
		{
			return after != null
				? await broadcastsRepository.GetBroadcastsAfter(after.Value)
				: await broadcastsRepository.GetNextBroadcasts(await seasonsRepository.GetCurrentSeasonRaces(time.Now));
		}

		public Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return broadcastsRepository.GetSessionTypes();
		}

		public Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request)
		{
			return broadcastsRepository.AddSessionType(request);
		}

		public BroadcastsService(
			IBroadcastsRepository broadcastsRepository,
			ISeasonsRepository seasonsRepository,
			ITimeService time)
		{
			this.broadcastsRepository = broadcastsRepository;
			this.seasonsRepository = seasonsRepository;
			this.time = time;
		}
	}
}
