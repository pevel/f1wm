using System;

namespace F1WM.ApiModel
{
	public class LapResultSummary
	{
		public DriverSummary Driver { get; set; }
		public TimeSpan Time { get; set; }
	}
}