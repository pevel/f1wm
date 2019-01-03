using System;

namespace F1WM.ApiModel
{
	public class PracticeSessionResultPosition
	{
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tyres { get; set; }
		public int Number { get; set; }
		public int FinishPosition { get; set; }
		public TimeSpan Time { get; set; }
		public int FinishedLaps { get; set; }
	}
}