using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class OtherSession
	{
		public uint Id { get; set; }
		public uint RaceId { get; set; }
		public string Session { get; set; }
		public uint EntryId { get; set; }
		public byte FinishPosition { get; set; }
		public TimeSpan Time { get; set; }
		public byte FinishedLaps { get; set; }
		public virtual Entry Entry { get; set; }
	}
}