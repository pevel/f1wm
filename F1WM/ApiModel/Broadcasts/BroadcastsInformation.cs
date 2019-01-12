using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastsInformation
	{
		public int RaceId { get; set; }
		public IEnumerable<BroadcastedSession> Sessions { get; set; }
		public IEnumerable<Broadcaster> Broadcasters { get; set; }
	}
}