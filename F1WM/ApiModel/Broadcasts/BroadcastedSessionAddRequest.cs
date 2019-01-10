using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastedSessionAddRequest
	{
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public IEnumerable<BroadcastAddRequest> Broadcasts { get; set; }
	}
}