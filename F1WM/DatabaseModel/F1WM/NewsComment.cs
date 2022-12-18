using System;

namespace F1WM.DatabaseModel
{
	public class NewsComment
	{
		public int Id { get; set; }
		public int NewsId { get; set; }
		public int PosterId { get; set; }
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