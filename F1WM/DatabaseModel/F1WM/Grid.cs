using System;

namespace F1WM.DatabaseModel
{
	public class Grid
	{
		public int EntryId { get; set; }
		public int RaceId { get; set; }
		public string StartPositionOrStatus { get; set; }
		public int? StartPosition { get; set; }
		public string StartStatus { get; set; }
		public byte Ord { get; set; }
		public TimeSpan Time { get; set; }
		public virtual Entry Entry { get; set; }
		public virtual Race Race { get; set; }
	}
}