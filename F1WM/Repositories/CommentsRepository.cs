using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class CommentsRepository : ICommentsRepository
	{
		private F1WMContext context;
		private IMapper mapper;

		public Comment GetComment(int id)
		{
			var dbComment = context.F1NewsComs
				.Include(c => c.Text)
				.FirstOrDefault(c => c.Id == id);
			return mapper.Map<Comment>(dbComment);
		}

		public IEnumerable<Comment> GetCommentsByNewsId(int newsId)
		{
			var dbComments = context.F1NewsComs
				.Include(c => c.Text)
				.Where(c => c.NewsId == newsId)
				.OrderByDescending(c => c.Date);
			return mapper.Map<IEnumerable<Comment>>(dbComments);
		}

		public CommentsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}