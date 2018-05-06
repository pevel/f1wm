using System.Collections.Generic;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ICommentsService
	{
		IEnumerable<Comment> GetCommentsByNewsId(int newsId);
		Comment GetComment(int id);
	}
}