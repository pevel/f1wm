using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class BroadcastedSession
	{
		public int Id { get; set; }
		public int BroadcastedSessionNameId { get; set; }
		public DateTime Start { get; set; }
		public virtual IEnumerable<Broadcast> Broadcasts { get; set; }
		public virtual BroadcastedSessionType Type { get; set; }
	}
}
