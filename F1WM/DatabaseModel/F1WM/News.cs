using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class News
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public byte TypeId { get; set; }
		public int? NewsModified { get; set; }
		public string PosterName { get; set; }
		public int MainTagId { get; set; }
		public NewsTag MainTag { get; set; }
		public string Redirect { get; set; }
		public bool NewsHidden { get; set; }
		public int CommentCount { get; set; }
		public bool IsHighlighted { get; set; }
		public int Views { get; set; }
		public int PosterId { get; set; }
		public int NewsDateym { get; set; }
		public bool CommBlock { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Text { get; set; }
		public virtual IEnumerable<NewsTagMatch> Tags { get; set; }
		public virtual Article Article { get; set; }
	}
}
