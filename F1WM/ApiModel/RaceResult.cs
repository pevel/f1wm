using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceResult
	{
		IEnumerable<RaceResultPosition> Results { get; set; }
		public double WinnersAverageSpeed { get; set; }
		public LapResultSummary FastestLap { get; set; }
	}
}