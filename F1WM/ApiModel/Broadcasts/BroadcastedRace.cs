using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class BroadcastedRace
	{
		public uint Id { get; set; }
		public virtual IEnumerable<BroadcastedSession> BroadcastedSessions { get; set; }
	}
}
