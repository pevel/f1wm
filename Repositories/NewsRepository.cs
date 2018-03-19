using System.Collections.Generic;
using Dapper;
using F1WM.Model;
using F1WM.Utilities;

namespace F1WM.Repositories
{
	public class NewsRepository : INewsRepository
	{
		private DbContext db;

		public IEnumerable<News> GetNews(int? firstId = null, int? count = Constants.NewsCount)
		{
			if (firstId != null)
			{
				return this.db.Connection.Query<News>(
					@"SELECT
					n2.news_id as Id,
					n2.news_date as Date,
					n2.news_title as Title
					FROM f1_news n1
					JOIN f1_news n2
					ON n1.news_id = @firstId
					WHERE n1.news_date >= n2.news_date
					ORDER BY n2.news_date DESC
					LIMIT 0, @count",
					new { firstId = firstId, count = count });
			}
			else
			{
				return this.db.Connection.Query<News>(
					@"SELECT
					news_id as Id,
					news_date as Date,
					news_title as Title
					FROM f1_news
					ORDER BY news_date DESC
					LIMIT 0, @count",
					new { count = count });
			}
		}

		public NewsRepository(DbContext db)
		{
			this.db = db;
		}
	}
}