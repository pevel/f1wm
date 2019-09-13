using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DomainModel;

namespace F1WM.Repositories
{
	public interface IBroadcastsRepository
	{
		Task<BroadcastsInformation> AddBroadcasts(BroadcastsAddRequest request);
		Task<ApiModel.Broadcaster> AddBroadcaster(BroadcasterAddRequest request);
		Task<IEnumerable<ApiModel.Broadcaster>> GetBroadcasters();
		Task<BroadcastsInformation> GetBroadcastsAfter(DateTime now);
		Task<IEnumerable<BroadcastSessionType>> GetSessionTypes();
		Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request);
		Task<BroadcastsInformation> GetNextBroadcasts(SeasonRaces currentSeason);
		Task<BroadcastsInformation> UpdateBroadcasts(BroadcastsUpdateRequest request);
	}
}
