using F1WM.ApiModel;

namespace F1WM.Utilities
{
	public class SqlStringBuilder
	{
		public string GetEncodingSet()
		{
			return "SET NAMES utf8mb4; ";
		}

		public string GetNewsSummaryFields(string tablePrefix = null)
		{
			tablePrefix = PrepareTablePrefix(tablePrefix);
			return $@"{GetNewsBaseFields(tablePrefix)},
				{tablePrefix}comm_count as {nameof(NewsSummary.CommentCount)},
				{tablePrefix}news_highlight as {nameof(NewsSummary.IsHighlighted)},
				{tablePrefix}topic_id as {nameof(NewsSummary.TopicId)}";
		}

		public string GetNewsDetailsFields(string tablePrefix = null)
		{
			tablePrefix = PrepareTablePrefix(tablePrefix);
			return $@"{GetNewsBaseFields(tablePrefix)},
				{tablePrefix}poster_name as {nameof(NewsDetails.PosterName)},
				{tablePrefix}news_views as {nameof(NewsDetails.Views)},
				{tablePrefix}news_text as {nameof(NewsDetails.Text)}";
		}

		public string GetCommentFields(string tablePrefix = null)
		{
			tablePrefix = PrepareTablePrefix(tablePrefix);
			return $@"{tablePrefix}comm_id as {nameof(Comment.Id)},
				{tablePrefix}news_id as {nameof(Comment.NewsId)},
				{tablePrefix}poster_id as {nameof(Comment.PosterId)},
				{tablePrefix}poster_name as {nameof(Comment.PosterName)},
				FROM_UNIXTIME({tablePrefix}comm_time) as {nameof(Comment.Date)},
				{tablePrefix}comm_status as {nameof(Comment.Status)}";
		}

		private string GetNewsBaseFields(string tablePrefix = null)
		{
			return $@"
				{tablePrefix}news_id as {nameof(NewsBase.Id)},
				{tablePrefix}news_date as {nameof(NewsBase.Date)},
				{tablePrefix}news_redirect as {nameof(NewsBase.Redirect)},
				{tablePrefix}news_title as {nameof(NewsBase.Title)},
				{tablePrefix}news_subtitle as {nameof(NewsBase.Subtitle)}";
		}

		private string PrepareTablePrefix(string prefix)
		{
			return string.IsNullOrEmpty(prefix) ? "" : prefix + ".";
		}
	}
}