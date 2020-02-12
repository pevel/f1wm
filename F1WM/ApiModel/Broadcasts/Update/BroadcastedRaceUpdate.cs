using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastedRaceUpdate
	{
		[Required]
		public virtual IList<BroadcastedSessionUpdateRequest> BroadcastedSessions { get; set; }
	}
}
