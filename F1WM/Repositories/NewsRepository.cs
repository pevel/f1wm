using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<NewsSummary> GetLatestNews(int count, int? firstId = null)
		{
			IEnumerable<News> dbNews;
			if (firstId != null)
			{
				dbNews = context.F1News
					.Join(context.F1News, n1 => (int)n1.Id, n2 => firstId.Value, (n1, n2) => new { n1, n2 })
					.Where(n => n.n1.Date >= n.n2.Date)
					.Select(n => n.n2)
					.Include(n => n.Topic)
					.Where(n => !n.NewsHidden)
					.OrderByDescending(n => n.Date)
					.Take(count);
			}
			else
			{
				dbNews = context.F1News
					.Where(n => !n.NewsHidden)
					.Include(n => n.Topic)
					.OrderByDescending(n => n.Date)
					.Take(count);
			}
			return mapper.Map<IEnumerable<NewsSummary>>(dbNews);
		}

		public NewsDetails GetNewsDetails(int id)
		{
			var dbNews = context.F1News
				.Where(n => n.Id == id && !n.NewsHidden)
				.FirstOrDefault();
			var news = mapper.Map<NewsDetails>(dbNews);
			if (news != null)
			{
				news.PreviousNewsId = (int?)context.F1News
					.Where(n => n.Date < news.Date && !n.NewsHidden)
					.OrderByDescending(n => n.Date)
					.FirstOrDefault()?.Id;
				news.NextNewsId = (int?)context.F1News
					.Where(n => n.Date > news.Date && !n.NewsHidden)
					.OrderBy(n => n.Date)
					.FirstOrDefault()?.Id;
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