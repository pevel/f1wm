using System.Collections.Generic;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ICommentsRepository
	{
		IEnumerable<Comment> GetCommentsByNewsId(int newsId);
		Comment GetComment(int id);
	}
}