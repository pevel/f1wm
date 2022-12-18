using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class BroadcastedSession
	{
		public int Id { get; set; }
		public int BroadcastedSessionTypeId { get; set; }
		public DateTime Start { get; set; }
		public int RaceId { get; set; }
		public virtual IList<Broadcast> Broadcasts { get; set; }
		public virtual BroadcastedSessionType Type { get; set; }
		public virtual Race Race { get; set; }
	}
}
