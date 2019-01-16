using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class News
	{
		public uint Id { get; set; }
		public DateTime Date { get; set; }
		public byte Type { get; set; }
		public int? NewsModified { get; set; }
		public string PosterName { get; set; }
		public uint TopicId { get; set; }
		public NewsTopic Topic { get; set; }
		public string Redirect { get; set; }
		public bool NewsHidden { get; set; }
		public ushort CommentCount { get; set; }
		public bool IsHighlighted { get; set; }
		public uint Views { get; set; }
		public uint PosterId { get; set; }
		public uint NewsDateym { get; set; }
		public bool CommBlock { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Text { get; set; }
	}
}
