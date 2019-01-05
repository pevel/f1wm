using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class OtherResultPosition
	{
		public int FinishPosition { get; set; }
		public string Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public OtherResultStatus Status { get; set; }
		public int Points { get; set; }
	}
}