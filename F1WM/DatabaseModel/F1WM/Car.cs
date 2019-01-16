using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Car
	{
		public uint Id { get; set; }
		public uint ContstructorId { get; set; }
		public string Name { get; set; }
		public uint? Launch1newsid { get; set; }
		public uint? Launch2newsid { get; set; }
		public string Litera { get; set; }
		public uint Albumid { get; set; }
		public virtual Constructor Constructor { get; set; }
		public virtual IEnumerable<Entry> Entries { get; set; }
	}
}
