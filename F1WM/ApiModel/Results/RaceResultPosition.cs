using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class RaceResultPosition
	{
		public int? Position { get; set; }
		public int PositionChange { get; set; }
		public int Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tyres { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		public int PitStopVisits { get; set; }
		public string NotFinishedReason { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ResultStatus Status { get; set; }
	}
}