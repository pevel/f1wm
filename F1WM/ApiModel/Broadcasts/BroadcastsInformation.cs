using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastsInformation
	{
		public int RaceId { get; set; }
		public IEnumerable<SessionSummary> Sessions { get; set; }
		public IEnumerable<Broadcaster> Broadcasters { get; set; }
	}
}