using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class TeamSummary
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public uint? Id { get; set; }
		public string Name { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Logo { get; set; }
	}
}
