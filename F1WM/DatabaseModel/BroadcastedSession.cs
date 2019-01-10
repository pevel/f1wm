using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1WM.DatabaseModel
{
	public class BroadcastedSession
	{
		public int Id { get; set; }
		[MaxLength(255)]
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public virtual IEnumerable<Broadcast> Broadcasts { get; set; }
	}
}