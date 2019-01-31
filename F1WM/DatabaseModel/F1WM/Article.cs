using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Article
	{
		public uint Id { get; set; }
		public uint ArticleCategoryId { get; set; }
		public uint NewsId { get; set; }
		public string Title { get; set; }
		public string Poster { get; set; }
		public byte IsHidden { get; set; }
		public uint Views { get; set; }
		public string Preview { get; set; }
		public string Text { get; set; }
		public virtual News News { get; set; }
	}
}
