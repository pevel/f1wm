using System;

namespace F1WM.ApiModel
{
	public class NextRaceSummary
	{
		public string Name { get; set; }
		public string TranslatedName { get; set; }
		public DateTime Date { get; set; }
		public TrackSummary Track { get; set; }
		public LapResultSummary LastYearPolePositionLapResult { get; set; }
		public RaceResultSummary LastYearWinnerRaceResult { get; set; }
		public LapResultSummary LastYearFastestLapResult { get; set; }
	}
}