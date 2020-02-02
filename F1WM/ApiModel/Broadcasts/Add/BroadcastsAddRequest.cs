using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastsAddRequest
	{
		public int RaceId { get; set; }
		public IEnumerable<BroadcastedSessionAddRequest> Sessions { get; set; }
	}
}