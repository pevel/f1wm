using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel.Results
{
	public class WinnerRaceResultSummary
	{
		public int Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		public string Information { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ResultStatus Status { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public StartStatus StartStatus { get; set; }
	}
}