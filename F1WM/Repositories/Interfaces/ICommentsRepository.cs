using System.Collections.Generic;
using F1WM.Model;

namespace F1WM.Repositories
{
	public interface ICommentsRepository
	{
		IEnumerable<Comment> GetCommentsByNewsId(int newsId);
		Comment GetComment(int id);
	}
}