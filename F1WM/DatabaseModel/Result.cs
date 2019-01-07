using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Result
	{
		public uint EntryId { get; set; }
		public uint RaceId { get; set; }
		public string PositionOrStatus { get; set; }
		public int? FinishPosition { get; set; }
		public string Status { get; set; }
		public byte FinishedLaps { get; set; }
		public string Information { get; set; }
		public byte Ord { get; set; }
		public byte? PitStopVisits { get; set; }
		public TimeSpan Time { get; set; }
		public virtual Entry Entry { get; set; }
		public virtual Race Race { get; set; }
	}
}