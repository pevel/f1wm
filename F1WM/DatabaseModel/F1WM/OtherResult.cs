using System;

namespace F1WM.DatabaseModel
{
	public class OtherResult
	{
		public int Id { get; set; }
		public int EventId { get; set; }
		public ushort FinishedLaps { get; set; }
		public TimeSpan Time { get; set; }
		public byte FinishPosition { get; set; }
		public string Status { get; set; }
		public int OtherEntryId { get; set; }
		public ushort? OtherAdditionalPointsReasonId { get; set; }
		public byte Pozklasa { get; set; }
		public int Points { get; set; }
		public virtual Event Event { get; set; }
		public virtual OtherEntry Entry { get; set; }
		public virtual OtherAdditionalPointsReason AdditionalPointsReason { get; set; }
	}
}