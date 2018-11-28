using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Utilities;
using Narochno.BBCode;

namespace F1WM.Services
{
	public class CommentsService : ICommentsService
	{
		private readonly ICommentsRepository repository;
		private readonly IBBCodeParser bBCodeParser;

		public async Task<Comment> GetComment(int id)
		{
			var comment = await repository.GetComment(id);
			if (comment != null)
			{
				comment.Text = WebUtility.HtmlDecode(bBCodeParser.ToHtml(comment.Text.Cleanup()));
			}
			return comment;
		}

		public async Task<IEnumerable<Comment>> GetCommentsByNewsId(int newsId)
		{
			var comments = await repository.GetCommentsByNewsId(newsId);
			return comments.Select(comment =>
			{
				comment.Text = WebUtility.HtmlDecode(bBCodeParser.ToHtml(comment.Text.Cleanup()));
				return comment;
			}).ToList();
		}

		public CommentsService(ICommentsRepository repository, IBBCodeParser bBCodeParser)
		{
			this.repository = repository;
			this.bBCodeParser = bBCodeParser;
		}
	}
}