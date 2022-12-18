using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class TeamSummary
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Logo { get; set; }
	}
}
