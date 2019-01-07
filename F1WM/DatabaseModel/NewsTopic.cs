using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsTopic
	{
		public uint TopicId { get; set; }
		public string TopicTitle { get; set; }
		public string TopicIcon { get; set; }
		public uint CatId { get; set; }
		public uint Searches { get; set; }
	}
}