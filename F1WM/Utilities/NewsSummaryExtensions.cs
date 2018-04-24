using F1WM.Model;

namespace F1WM.Utilities
{
	public static class NewsSummaryExtensions
	{
		public static NewsSummary ResolveTopicIcon(this NewsSummary news)
		{
			if (!string.IsNullOrEmpty(news.TopicIcon))
			{
				news.TopicIcon = $"/img/ikony/{news.TopicIcon}.gif";
			}
			return news;
		}
	}
}