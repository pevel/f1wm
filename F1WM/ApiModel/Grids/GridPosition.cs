using System;

namespace F1WM.ApiModel
{
	public class GridPosition
	{
		public int StartPosition { get; set; }
		public TimeSpan Time { get; set; }
		public GridDriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
	}
}
