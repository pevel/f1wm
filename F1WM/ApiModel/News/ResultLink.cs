using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class ResultLink
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public ResultLinkType Type { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? RaceId { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? EventId { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Session { get; set; }
	}
}