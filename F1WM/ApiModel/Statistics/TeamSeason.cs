using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class TeamSeason
	{
		public SeasonSummary Season { get; set; }
		public int Starts { get; set; }
		public int GrandPrixCount { get; set; }
		public float? Points { get; set; }
		public int Wins { get; set; }
		public int Podiums { get; set; }
		public int PolePositions { get; set; }
		public int FastestLaps { get; set; }
		public int NotFinished { get; set; }
		public IEnumerable<CarSummary> Cars { get; set; }
		public IEnumerable<DriverSummary> Drivers { get; set; }
	}
}
