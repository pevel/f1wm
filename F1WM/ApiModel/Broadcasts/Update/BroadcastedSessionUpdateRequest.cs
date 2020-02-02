using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastedSessionUpdateRequest
	{
		public DateTime Start { get; set; }
		public virtual IEnumerable<BroadcastUpdateRequest> Broadcasts { get; set; }
	}
}
