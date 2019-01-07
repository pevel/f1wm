using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsCommentText
	{
		public uint CommId { get; set; }
		public string CommText { get; set; }
		public virtual NewsComment Comment { get; set; }
	}
}