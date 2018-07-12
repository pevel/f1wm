using System;

namespace F1WM.ApiModel
{
	public class NextRaceSummary
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public TrackSummary Track { get; set; }
		public LapResultSummary PolePositionLapResult { get; set; }
		public RaceResultSummary WinnerRaceResult { get; set; }
		public LapResultSummary FastestLapResult { get; set; }
	}
}