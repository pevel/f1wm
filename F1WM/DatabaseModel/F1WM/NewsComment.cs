using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsComment
	{
		public uint Id { get; set; }
		public uint NewsId { get; set; }
		public uint PosterId { get; set; }
		public string PosterName { get; set; }
		public DateTime Date
		{
			get
			{
				return DateTimeOffset.FromUnixTimeSeconds(UnixTime).DateTime;
			}
		}
		public int UnixTime { get; set; }
		public byte Status { get; set; }
		public string PosterIp { get; set; }
		public virtual NewsCommentText Text { get; set; }
	}
}