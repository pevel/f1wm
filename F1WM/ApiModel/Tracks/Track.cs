using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class Track : TrackSummary
	{
		public string City { get; set; }
		public string ShortName { get; set; }
		public Country Country { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public TrackStatus Status { get; set; }
	}
}
