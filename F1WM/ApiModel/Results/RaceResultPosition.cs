using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class RaceResultPosition
	{
		public int? FinishPosition { get; set; }
		public int? StartPosition { get; set; }
		public byte Number { get; set; }
		public DriverBase Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tyres { get; set; }
		public byte FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		public byte PitStopVisits { get; set; }
		public string Information { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ResultStatus Status { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public StartStatus StartStatus { get; set; }
	}
}
