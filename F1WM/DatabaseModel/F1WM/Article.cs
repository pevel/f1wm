namespace F1WM.DatabaseModel
{
	public class Article
	{
		public int Id { get; set; }
		public int ArticleCategoryId { get; set; }
		public int? NewsId { get; set; }
		public string Title { get; set; }
		public string Poster { get; set; }
		public byte IsHidden { get; set; }
		public int Views { get; set; }
		public string Preview { get; set; }
		public string Text { get; set; }
		public virtual News News { get; set; }
	}
}
