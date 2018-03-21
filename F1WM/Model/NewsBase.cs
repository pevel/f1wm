using System;

namespace F1WM.Model
{
	public class NewsBase
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Redirect { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
	}
}