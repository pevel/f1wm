using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceResult
	{
		public int RaceId { get; set; }
		public IEnumerable<RaceResultPosition> Results { get; set; }
		public double WinnerAverageSpeed { get; set; }
		public LapResultSummary FastestLap { get; set; }
	}
}