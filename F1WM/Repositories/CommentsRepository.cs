using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class CommentsRepository : RepositoryBase, ICommentsRepository
	{
		private readonly IMapper mapper;

		public async Task<Comment> GetComment(int id)
		{
			await SetDbEncoding();
			var dbComment = await context.NewsComments
				.Include(c => c.Text)
				.FirstOrDefaultAsync(c => c.Id == id);
			return mapper.Map<Comment>(dbComment);
		}

		public async Task<IEnumerable<Comment>> GetCommentsByNewsId(int newsId)
		{
			await SetDbEncoding();
			var dbComments = await context.NewsComments
				.Include(c => c.Text)
				.Where(c => c.NewsId == newsId)
				.OrderByDescending(c => c.UnixTime)
				.ToListAsync();
			return mapper.Map<IEnumerable<Comment>>(dbComments);
		}

		public CommentsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}