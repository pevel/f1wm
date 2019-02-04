using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class DriverSeason
	{
		public SeasonSummary Season { get; set; }
		public int Starts { get; set; }
		public int Points { get; set; }
		public int Wins { get; set; }
		public int Podiums { get; set; }
		public int AnyPoints { get; set; }
		public int PolePositions { get; set; }
		public int FastestLaps { get; set; }
		public int NotClassified { get; set; }
		public IEnumerable<TeamSummary> Teams { get; set; }
	}
}
