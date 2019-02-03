using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceFastestLaps
	{
		public int RaceId { get; set; }
		public IEnumerable<RaceFastestLap> Results { get; set; }
	}
}
