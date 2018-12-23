using System;

namespace F1WM.ApiModel
{
	public class OtherResultPosition
	{
		public int FinishPosition { get; set; }
		public int Number { get; set; }
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public int FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
	}
}