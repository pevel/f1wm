using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class TrackShortResultsByYear
	{
		public int Year { get; set; }
		public byte TrackVersion { get; set; }
		public TrackLapResultSummary PolePositionLapResult { get; set; }
		public TrackRaceResultSummary WinnerRaceResult { get; set; }
		public IEnumerable<TrackLapResultSummary> FastestLapResults { get; set; }
	}
}
