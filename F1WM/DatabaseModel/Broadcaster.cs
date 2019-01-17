using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1WM.DatabaseModel
{
	public class Broadcaster
	{
		public int Id { get; set; }
		[MaxLength(255)]
		public string Url { get; set; }
		[MaxLength(255)]
		public string Name { get; set; }
		[MaxLength(255)]
		public string Icon { get; set; }
		public virtual IEnumerable<Broadcast> Broadcasts { get; set; }
	}
}