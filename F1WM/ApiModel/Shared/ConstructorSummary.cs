using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class ConstructorSummary
	{
		public string Name { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Country Nationality { get; set; }
	}
}
