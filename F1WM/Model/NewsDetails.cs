namespace F1WM.Model
{
	public class NewsDetails : NewsBase
	{
		public string PosterName { get; set; }
		public int Views { get; set; }
		public string Text { get; set; }
		public int? NextNewsId { get; set; }
		public int? PreviousNewsId { get; set; }
	}
}