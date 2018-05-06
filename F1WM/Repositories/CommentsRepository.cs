using System.Collections.Generic;
using Dapper;
using F1WM.ApiModel;
using F1WM.Utilities;

namespace F1WM.Repositories
{
	public class CommentsRepository : ICommentsRepository
	{
		private IDbContext db;
		private SqlStringBuilder sqlStringBuilder;

		public Comment GetComment(int id)
		{
			return db.Connection.QueryFirstOrDefault<Comment>(
				$@"{this.sqlStringBuilder.GetEncodingSet()}
				SELECT {sqlStringBuilder.GetCommentFields("c")},
				t.comm_text as {nameof(Comment.Text)}
				FROM f1_news_coms c
				JOIN f1_news_comstext t ON c.comm_id = t.comm_id
				WHERE c.comm_id = @id",
				new { id = id });
		}

		public IEnumerable<Comment> GetCommentsByNewsId(int newsId)
		{
			return db.Connection.Query<Comment>(
				$@"{this.sqlStringBuilder.GetEncodingSet()}
				SELECT {sqlStringBuilder.GetCommentFields("c")},
				t.comm_text as {nameof(Comment.Text)}
				FROM f1_news_coms c
				JOIN f1_news_comstext t ON c.comm_id = t.comm_id
				WHERE c.news_id = @newsId
				ORDER BY {nameof(Comment.Date)} DESC",
				new { newsId = newsId });
		}

		public CommentsRepository(IDbContext db, SqlStringBuilder sqlStringBuilder)
		{
			this.db = db;
			this.sqlStringBuilder = sqlStringBuilder;
		}
	}
}