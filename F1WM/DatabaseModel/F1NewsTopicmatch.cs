using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1NewsTopicmatch
	{
		public uint MatchId { get; set; }
		public uint NewsId { get; set; }
		public uint TopicId { get; set; }
		public DateTime NewsDate { get; set; }
        public virtual News News { get; set; }
    }
}