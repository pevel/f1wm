namespace F1WM.ApiModel
{
	public class NewsSummary : NewsBase
	{
		public int CommentCount { get; set; }
		public bool IsHighlighted { get; set; }
		public string Type { get; set; }
		public string TopicIcon { get; set; }
		public int TopicId { get; set; }
	}
}