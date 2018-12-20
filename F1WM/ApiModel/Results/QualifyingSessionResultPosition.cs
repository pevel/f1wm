using System;

namespace F1WM.ApiModel
{
	public class QualifyingSessionResultPosition
	{
		public int FinishPosition { get; set; }
		public TimeSpan Time { get; set; }
		public int FinishedLaps { get; set; }
	}
}