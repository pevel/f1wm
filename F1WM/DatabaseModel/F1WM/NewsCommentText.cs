namespace F1WM.DatabaseModel
{
	public class NewsCommentText
	{
		public int CommentId { get; set; }
		public string Text { get; set; }
		public virtual NewsComment Comment { get; set; }
	}
}
