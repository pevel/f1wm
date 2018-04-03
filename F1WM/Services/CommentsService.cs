using System.Collections.Generic;
using System.Linq;
using F1WM.Model;
using F1WM.Repositories;
using Narochno.BBCode;

namespace F1WM.Services
{
	public class CommentsService : ICommentsService
	{
		private ICommentsRepository repository;
		private IBBCodeParser bBCodeParser;

		public Comment GetComment(int id)
		{
			var comment = repository.GetComment(id);
			comment.Text = bBCodeParser.ToHtml(comment.Text);
			return comment;
		}

		public IEnumerable<Comment> GetCommentsByNewsId(int newsId)
		{
			return repository.GetCommentsByNewsId(newsId).Select(comment =>
			{
				comment.Text = bBCodeParser.ToHtml(comment.Text);
				return comment;
			});
		}

		public CommentsService(ICommentsRepository repository, IBBCodeParser bBCodeParser)
		{
			this.repository = repository;
			this.bBCodeParser = bBCodeParser;
		}
	}
}