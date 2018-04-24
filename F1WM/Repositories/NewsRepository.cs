using System.Collections.Generic;
using Dapper;
using F1WM.Model;
using F1WM.Utilities;

namespace F1WM.Repositories
{
	public class NewsRepository : INewsRepository
	{
		private IDbContext db;
		private SqlStringBuilder sqlStringBuilder;

		public IEnumerable<NewsSummary> GetLatestNews(int count, int? firstId = null)
		{
			if (firstId != null)
			{
				return this.db.Connection.Query<NewsSummary>(
					$@"{this.sqlStringBuilder.GetEncodingSet()} 
					SELECT {this.sqlStringBuilder.GetNewsSummaryFields("n2")},
					topic.topic_icon as TopicIcon,
					type.type_title as Type
					FROM f1_news n1
					JOIN f1_news n2
					ON n1.news_id = @firstId
					JOIN f1_news_topics topic
					ON n2.topic_id = topic.topic_id
					JOIN f1_news_types type
					ON n2.news_type = type.type_id
					WHERE n1.news_date >= n2.news_date AND n2.news_hidden = 0
					ORDER BY n2.news_date DESC
					LIMIT 0, @count",
					new { firstId = firstId, count = count });
			}
			else
			{
				return this.db.Connection.Query<NewsSummary>(
					$@"{this.sqlStringBuilder.GetEncodingSet()}
					SELECT {this.sqlStringBuilder.GetNewsSummaryFields("n")},
					topic.topic_icon as TopicIcon,
					type.type_title as Type
					FROM f1_news n
					JOIN f1_news_topics topic
					ON n.topic_id = topic.topic_id
					JOIN f1_news_types type
					ON n.news_type = type.type_id
					WHERE n.news_hidden = 0
					ORDER BY n.news_date DESC
					LIMIT 0, @count",
					new { count = count });
			}
		}

		public NewsDetails GetNewsDetails(int id)
		{
			var news = this.db.Connection.QuerySingleOrDefault<NewsDetails>(
				$@"{this.sqlStringBuilder.GetEncodingSet()} 
				SELECT {this.sqlStringBuilder.GetNewsDetailsFields()}
				FROM f1_news
				WHERE news_id = @id",
				new { id = id });
			if (news != null)
			{
				news.PreviousNewsId = this.db.Connection.QuerySingleOrDefault<int?>(
				@"SELECT news_id
				FROM f1_news
				WHERE news_date < @date AND news_hidden = 0
				ORDER BY news_date DESC
				LIMIT 0,1",
				new { date = news.Date });
				news.NextNewsId = this.db.Connection.QuerySingleOrDefault<int?>(
				@"SELECT news_id
				FROM f1_news
				WHERE news_date > @date AND news_hidden = 0
				ORDER BY news_date ASC
				LIMIT 0,1",
				new { date = news.Date });
			}
			return news;
		}

		public NewsRepository(IDbContext db, SqlStringBuilder sqlStringBuilder)
		{
			this.db = db;
			this.sqlStringBuilder = sqlStringBuilder;
		}
	}
}