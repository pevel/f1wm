using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class TyresSummary
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? Id { get; set; }
		public string Name { get; set; }
	}
}
