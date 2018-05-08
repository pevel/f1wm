using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ICommentsService
	{
		Task<IEnumerable<Comment>> GetCommentsByNewsId(int newsId);
		Task<Comment> GetComment(int id);
	}
}