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
		Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request);
		Task<BroadcastsInformation> GetNextBroadcasts(SeasonRaces currentSeason);
		Task<BroadcastsInformation> GetBroadcastsAfter(DateTime now);
		Task<IEnumerable<BroadcastsInformation>> GetBroadcasts(int? raceId = null);
		Task<IEnumerable<ApiModel.Broadcaster>> GetBroadcasters();
		Task<IEnumerable<BroadcastSessionType>> GetSessionTypes();
		Task<BroadcastsInformation> UpdateBroadcasts(BroadcastsUpdateRequest request);
		Task<Broadcaster> UpdateBroadcaster(BroadcasterUpdateRequest request);
		Task<BroadcastSessionType> UpdateSessionType(BroadcastSessionTypeUpdateRequest request);
		Task DeleteBroadcasts(int raceId);
		Task DeleteBroadcaster(int id);
		Task DeleteSessionType(int id);
	}
}
