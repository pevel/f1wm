using System;

namespace F1WM.ApiModel
{
	public class NewsBase
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
	}
}
