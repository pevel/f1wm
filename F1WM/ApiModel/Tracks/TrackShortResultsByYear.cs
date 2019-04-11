namespace F1WM.ApiModel
{
	public class TrackShortResultsByYear
	{
		public int Year { get; set; }
		public int TrackVersion { get; set; }
		public TrackLapResultSummary PolePositionLapResult { get; set; }
		public TrackRaceResultSummary WinnerRaceResult { get; set; }
		public TrackLapResultSummary FastestLapResult { get; set; }
	}
}
