using System;

namespace F1WM.ApiModel
{
	public class FastestLapResultSummary : LapResultSummary
	{
		public CarSummary Car { get; set; }
		public int LapNumber { get; set; }
	}
}