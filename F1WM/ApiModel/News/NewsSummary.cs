namespace F1WM.ApiModel
{
	public class NewsSummary : NewsBase
	{
		public int CommentCount { get; set; }
		public bool IsHighlighted { get; set; }
		public byte TypeId { get; set; }
		public int TopicId { get; set; }
	}
}