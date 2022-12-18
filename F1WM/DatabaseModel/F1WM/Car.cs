using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Car
	{
		public int Id { get; set; }
		public int ContstructorId { get; set; }
		public string Name { get; set; }
		public int? Launch1newsid { get; set; }
		public int? Launch2newsid { get; set; }
		public string Litera { get; set; }
		public int Albumid { get; set; }
		public virtual Constructor Constructor { get; set; }
		public virtual IEnumerable<Entry> Entries { get; set; }
	}
}
