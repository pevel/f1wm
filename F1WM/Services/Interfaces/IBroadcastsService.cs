using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DomainModel;

namespace F1WM.Services
{
	public interface IBroadcastsService
	{
		Task<BroadcastsInformation> AddBroadcasts(BroadcastsAddRequest request);
		Task<Broadcaster> AddBroadcaster(BroadcasterAddRequest request);
		Task<BroadcastSessionType> AddSessionType(BroadcastSessionTypeAddRequest request);
		Task<BroadcastsInformation> GetNextBroadcasts(DateTime? after = null);
		Task<IEnumerable<BroadcastsInformation>> GetBroadcasts(int? raceId = null);
		Task<BroadcastedRace> GetBroadcastedRace(int raceId);
		Task<IEnumerable<Broadcaster>> GetBroadcasters();
		Task<IEnumerable<BroadcastSessionType>> GetSessionTypes();
		Task<BroadcastedRace> UpdateBroadcasts(BroadcastsUpdateRequest request);
		Task<Broadcaster> UpdateBroadcaster(BroadcasterUpdateRequest request);
		Task<BroadcastSessionType> UpdateSessionType(BroadcastSessionTypeUpdateRequest request);
		Task DeleteBroadcasts(int raceId);
		Task DeleteBroadcaster(int id);
		Task DeleteSessionType(int id);
	}
}
