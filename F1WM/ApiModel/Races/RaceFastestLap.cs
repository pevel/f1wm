using System;

namespace F1WM.ApiModel
{
	public class RaceFastestLap : LapResultSummary
	{
		public byte Number { get; set; }
		public byte LapNumber { get; set; }
		public CarSummary Car { get; set; }
		public TyresSummary Tyres { get; set; }
	}
}
