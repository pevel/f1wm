using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class TrackShortResultsByYears
	{
		public int TrackId { get; set; }
		public int CurrentTrackVersion { get; set; }
		public IEnumerable<TrackShortResultsByYear> Results { get; set; }
	}
}
