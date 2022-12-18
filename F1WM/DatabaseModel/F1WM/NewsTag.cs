namespace F1WM.DatabaseModel
{
	public class NewsTag
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int CategoryId { get; set; }
		public int Searches { get; set; }
		public string Icon { get; set; }
	}
}
