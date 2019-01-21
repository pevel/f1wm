using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsTag
	{
		public uint Id { get; set; }
		public string Title { get; set; }
		public uint CategoryId { get; set; }
		public uint Searches { get; set; }
	}
}
