using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class NewsDetails : NewsBase
	{
		public string PosterName { get; set; }
		public int Views { get; set; }
		public string Text { get; set; }
		public int? NextNewsId { get; set; }
		public int? PreviousNewsId { get; set; }
		public ResultLink ResultLink { get; set; }
		public string Redirect { get; set; }
		public IEnumerable<NewsTag> RelatedTags { get; set; }
	}
}
