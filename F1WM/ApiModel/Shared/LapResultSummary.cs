using System;

namespace F1WM.ApiModel
{
	public class LapResultSummary
	{
		public DriverBase Driver { get; set; }
		public TimeSpan Time { get; set; }
	}
}
