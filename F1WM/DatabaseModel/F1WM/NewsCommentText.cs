using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsCommentText
	{
		public uint CommentId { get; set; }
		public string Text { get; set; }
		public virtual NewsComment Comment { get; set; }
	}
}
