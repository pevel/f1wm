using System;

namespace F1WM.ApiModel
{
	public class RaceResultPosition
	{
		public int Position { get; set; }
		public int PositionChange { get; set; }
		public int Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tires { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		public int PitStopVisits { get; set; }
		public string DisqualifiedReason { get; set; }
	}
}