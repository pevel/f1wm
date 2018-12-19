using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class LastRaceSummary : RaceSummaryBase
	{
		public int RaceNewsId { get; set; }
		public LapResultSummary PolePositionLapResult { get; set; }
		public FastestLapResultSummary FastestLapResult { get; set; }
		public IEnumerable<RaceResultPosition> ShortResults { get; set; }
	}
}