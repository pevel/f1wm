using System;

namespace F1WM.ApiModel
{
	public class LastRaceSummary : RaceSummaryBase
	{
		public TrackSummary Track { get; set; }
		public LapResultSummary LastPolePositionLapResult { get; set; }
		public RaceResultSummary LastWinnerRaceResult { get; set; }
		public LapResultSummary LastFastestLapResult { get; set; }
	}
}