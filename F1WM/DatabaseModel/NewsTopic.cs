using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsTopic
	{
		public uint Id { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
		public uint CategoryId { get; set; }
		public uint Searches { get; set; }
	}
}