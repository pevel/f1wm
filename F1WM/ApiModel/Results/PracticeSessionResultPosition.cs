using System;

namespace F1WM.ApiModel
{
	public class PracticeSessionResultPosition
	{
		public DriverBase Driver { get; set; }
		public CarSummary Car { get; set; }
		public string Tyres { get; set; }
		public byte Number { get; set; }
		public byte FinishPosition { get; set; }
		public TimeSpan Time { get; set; }
		public byte FinishedLaps { get; set; }
	}
}
