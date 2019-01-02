using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class OtherResultPosition
	{
		public int FinishPosition { get; set; }
		public string Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tyres { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? AdditionalPoints { get; set; }
	}
}