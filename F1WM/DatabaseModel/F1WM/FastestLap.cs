using System;

namespace F1WM.DatabaseModel
{
	public class FastestLap
	{
		public int EntryId { get; set; }
		public int RaceId { get; set; }
		public string PositionOrStatus { get; set; }
		public byte LapNumber { get; set; }
		public byte Order { get; set; }
		public TimeSpan Time { get; set; }
		public virtual Entry Entry { get; set; }
		public virtual Race Race { get; set; }
	}
}
