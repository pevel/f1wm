using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class NewsRepository : RepositoryBase, INewsRepository
	{
		private readonly IMapper mapper;

		public async Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids)
		{
			await SetDbEncoding();
			var dbNews = await context.News.Where(n => ids.Contains(n.Id)).ToListAsync();
			return mapper.Map<IEnumerable<NewsSummary>>(dbNews);
		}

		public async Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId = null)
		{
			await SetDbEncoding();
			IEnumerable<News> dbNews;
			if (firstId != null)
			{
				dbNews = await context.News
					.Join(context.News, n1 => (int)n1.Id, n2 => firstId.Value, (n1, n2) => new { n1, n2 })
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
				dbNews = await context.News
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
			await SetDbEncoding();
			var dbNews = await context.News
				.Where(n => n.Id == id && !n.NewsHidden)
				.FirstOrDefaultAsync();
			var news = mapper.Map<NewsDetails>(dbNews);
			if (news != null)
			{
				news.PreviousNewsId = (int?)(await context.News
					.Where(n => n.Date < news.Date && !n.NewsHidden)
					.OrderByDescending(n => n.Date)
					.FirstOrDefaultAsync())?.Id;
				news.NextNewsId = (int?)(await context.News
					.Where(n => n.Date > news.Date && !n.NewsHidden)
					.OrderBy(n => n.Date)
					.FirstOrDefaultAsync())?.Id;
				if (news.Redirect != null && news.Redirect.TryParseResultRedirect(out ResultRedirectLink link))
				{
					news.ResultLink = new ResultLink()
					{
						Type = Constants.ResultTypeToLinkType[link.ResultType],
						RaceId = (int?)(await context.Races
							.FirstOrDefaultAsync(r => r.Date.Year == link.Year && r.Numinseason == link.Number))
							?.Id
					};
				}
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