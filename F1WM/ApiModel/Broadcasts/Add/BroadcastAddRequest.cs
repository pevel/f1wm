using System;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastAddRequest
	{
		[Required]
		public int BroadcasterId { get; set; }
		[Required]
		public DateTime Start { get; set; }
	}
}
