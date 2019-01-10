using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class BroadcastedSession
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public virtual IEnumerable<Broadcast> Broadcasts { get; set;}
	}
}