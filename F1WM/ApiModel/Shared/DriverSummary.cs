using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class DriverSummary : DriverBase
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Country Nationality { get; set; }
	}
}
