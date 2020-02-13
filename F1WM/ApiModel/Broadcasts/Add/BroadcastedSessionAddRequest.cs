using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastedSessionAddRequest
	{
		[Required]
		public int BroadcastedSessionTypeId { get; set; }
		[Required]
		public DateTime Start { get; set; }
		public IEnumerable<BroadcastAddRequest> Broadcasts { get; set; }
	}
}
