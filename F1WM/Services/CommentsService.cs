using System.Collections.Generic;
using System.Linq;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Utilities;
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
			if (comment != null)
			{
				comment.Text = bBCodeParser.ToHtml(comment.Text.Cleanup());
			}
			return comment;
		}

		public IEnumerable<Comment> GetCommentsByNewsId(int newsId)
		{
			return repository.GetCommentsByNewsId(newsId).Select(comment =>
			{
				comment.Text = bBCodeParser.ToHtml(comment.Text.Cleanup());
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