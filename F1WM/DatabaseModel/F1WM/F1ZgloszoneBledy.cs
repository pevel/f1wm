using System;

namespace F1WM.DatabaseModel
{
	public class F1ZgloszoneBledy
	{
		public string Id { get; set; }
		public DateTime Data { get; set; }
		public int UserId { get; set; }
		public int NewsId { get; set; }
		public int ArtId { get; set; }
		public string Zglaszajacy { get; set; }
		public string OpisBledu { get; set; }
		public int CommId { get; set; }
		public byte Typ { get; set; }
	}
}