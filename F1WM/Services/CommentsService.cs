using System.Collections.Generic;
using F1WM.Model;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class CommentsService : ICommentsService
	{
		private ICommentsRepository repository;

		public Comment GetComment(int id)
		{
			return repository.GetComment(id);
		}

		public IEnumerable<Comment> GetCommentsByNewsId(int newsId)
		{
			return repository.GetCommentsByNewsId(newsId);
		}

		public CommentsService(ICommentsRepository repository)
		{
			this.repository = repository;
		}
	}
}