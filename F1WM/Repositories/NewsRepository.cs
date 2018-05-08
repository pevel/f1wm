using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class NewsRepository : INewsRepository
	{
		private F1WMContext context;
		private IMapper mapper;

		public async Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId = null)
		{
			IEnumerable<News> dbNews;
			if (firstId != null)
			{
				dbNews = await context.F1News
					.Join(context.F1News, n1 => (int)n1.Id, n2 => firstId.Value, (n1, n2) => new { n1, n2 })
					.Where(n => n.n1.Date >= n.n2.Date)
					.Select(n => n.n2)
					.Include(n => n.Topic)
					.Where(n => !n.NewsHidden)
					.OrderByDescending(n => n.Date)
					.Take(count)
					.ToListAsync();
			}
			else
			{
				dbNews = await context.F1News
					.Where(n => !n.NewsHidden)
					.Include(n => n.Topic)
					.OrderByDescending(n => n.Date)
					.Take(count)
					.ToListAsync();
			}
			return mapper.Map<IEnumerable<NewsSummary>>(dbNews);
		}

		public async Task<NewsDetails> GetNewsDetails(int id)
		{
			var dbNews = await context.F1News
				.Where(n => n.Id == id && !n.NewsHidden)
				.FirstOrDefaultAsync();
			var news = mapper.Map<NewsDetails>(dbNews);
			if (news != null)
			{
				news.PreviousNewsId = (int?)(await context.F1News
					.Where(n => n.Date < news.Date && !n.NewsHidden)
					.OrderByDescending(n => n.Date)
					.FirstOrDefaultAsync())?.Id;
				news.NextNewsId = (int?)(await context.F1News
					.Where(n => n.Date > news.Date && !n.NewsHidden)
					.OrderBy(n => n.Date)
					.FirstOrDefaultAsync())?.Id;
			}
			return news;
		}

		public NewsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}