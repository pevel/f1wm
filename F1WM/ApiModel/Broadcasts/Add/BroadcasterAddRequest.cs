using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcasterAddRequest
	{
		public string Url { get; set; }
		[Required]
		public string Name { get; set; }
		public string Icon { get; set; }
	}
}
