using System;

namespace F1WM.ApiModel
{
	public class AverageSpeedResult
	{
		public DriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public double AverageSpeed { get; set; }
		public DateTime RaceDate { get; set; }
	}
}
