using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastsUpdateRequest
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public int RaceId { get; set; }
		[Required]
		public IEnumerable<BroadcastedSessionAddRequest> Sessions { get; set; }
	}
}
