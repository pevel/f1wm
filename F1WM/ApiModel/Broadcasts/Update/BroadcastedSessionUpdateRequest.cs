using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastedSessionUpdateRequest
	{
		public DateTime Start { get; set; }
		public virtual IList<BroadcastUpdateRequest> Broadcasts { get; set; }
	}
}
