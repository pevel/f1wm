using System;

namespace F1WM.DatabaseModel
{
	public class NewsTagMatch
	{
		public int Id { get; set; }
		public int NewsId { get; set; }
		public int TagId { get; set; }
		public DateTime NewsDate { get; set; }
		public virtual News News { get; set; }
		public virtual NewsTag Tag { get; set; }
	}
}
