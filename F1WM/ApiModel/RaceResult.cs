using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceResult
	{
		public IEnumerable<RaceResultPosition> Results { get; set; }
		public double WinnerAverageSpeed { get; set; }
		public LapResultSummary FastestLap { get; set; }
	}
}