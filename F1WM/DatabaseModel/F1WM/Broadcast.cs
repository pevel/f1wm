using System;

namespace F1WM.DatabaseModel
{
	public class Broadcast
	{
		public int Id { get; set; }
		public int BroadcasterId { get; set; }
		public int BroadcastedSessionId { get; set; }
		public DateTime Start { get; set; }
		public virtual Broadcaster Broadcaster { get; set; }
		public virtual BroadcastedSession BroadcastedSession { get; set; }
	}
}