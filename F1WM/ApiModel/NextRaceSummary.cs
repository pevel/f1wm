using System;

namespace F1WM.ApiModel
{
	public class NextRaceSummary
	{
		public string Name { get; set; }
		public string TranslatedName { get; set; }
		public DateTime Date { get; set; }
		public TrackSummary Track { get; set; }
		public LapResultSummary LastPolePositionLapResult { get; set; }
		public RaceResultSummary LastWinnerRaceResult { get; set; }
		public LapResultSummary LastFastestLapResult { get; set; }
	}
}