using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class FastestLap
	{
		public uint EntryId { get; set; }
		public uint RaceId { get; set; }
		public string PositionOrStatus { get; set; }
		public byte LapNumber { get; set; }
		public byte Order { get; set; }
		public TimeSpan Time { get; set; }
		public virtual Entry Entry { get; set; }
		public virtual Race Race { get; set; }
	}
}
