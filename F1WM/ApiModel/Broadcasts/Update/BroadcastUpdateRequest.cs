using System;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastUpdateRequest
	{
		[Required]
		public DateTime Start { get; set; }
	}
}
