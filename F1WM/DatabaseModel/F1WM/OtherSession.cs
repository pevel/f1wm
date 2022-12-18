using System;

namespace F1WM.DatabaseModel
{
	public class OtherSession
	{
		public int Id { get; set; }
		public int RaceId { get; set; }
		public string Session { get; set; }
		public int EntryId { get; set; }
		public byte FinishPosition { get; set; }
		public TimeSpan Time { get; set; }
		public byte FinishedLaps { get; set; }
		public virtual Entry Entry { get; set; }
		public virtual Race Race { get; set; }
	}
}
