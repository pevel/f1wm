using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceResult
	{
		public int RaceId { get; set; }
		public double Distance { get; set; }
		public IEnumerable<RaceResultPosition> Results { get; set; }
		public FastestLapResultSummary FastestLap { get; set; }
	}
}
