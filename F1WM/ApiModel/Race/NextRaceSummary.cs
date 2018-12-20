using System;

namespace F1WM.ApiModel
{
	public class NextRaceSummary : RaceSummaryBase
	{
		public LapResultSummary LastPolePositionLapResult { get; set; }
		public RaceResultSummary LastWinnerRaceResult { get; set; }
		public LapResultSummary LastFastestLapResult { get; set; }
	}
}