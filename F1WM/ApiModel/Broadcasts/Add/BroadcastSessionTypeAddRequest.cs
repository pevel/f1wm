using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastSessionTypeAddRequest
	{
		[Required]
		public string Name { get; set; }
	}
}
