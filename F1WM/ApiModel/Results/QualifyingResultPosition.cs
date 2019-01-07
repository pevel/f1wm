using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class QualifyingResultPosition
	{
		public int? FinishPosition { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public QualifyStatus Status { get; set; }
		public int Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Information { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public QualifyingSessionResultPosition Session1 { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public QualifyingSessionResultPosition Session2 { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public QualifyingSessionResultPosition Session3 { get; set; }
	}
}