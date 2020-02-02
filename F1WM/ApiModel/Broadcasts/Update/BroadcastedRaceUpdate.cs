using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastedRaceUpdate
	{
		public virtual IEnumerable<BroadcastedSessionUpdateRequest> BroadcastedSessions { get; set; }
	}
}
