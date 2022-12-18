using System;

namespace F1WM.DatabaseModel
{
	public class F1LogZmian
	{
		public string Id { get; set; }
		public DateTime Data { get; set; }
		public int UserId { get; set; }
		public int NewsId { get; set; }
		public int ArtId { get; set; }
		public int CommId { get; set; }
		public string Autor { get; set; }
		public string Zmiany { get; set; }
		public int TextId { get; set; }
	}
}