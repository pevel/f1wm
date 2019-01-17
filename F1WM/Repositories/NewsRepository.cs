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

		public async Task<NewsSummaryPaged> GetLatestNews(int? firstId, int page, int countPerPage)
		{
			await SetDbEncoding();
			IQueryable<News> dbNews;

			if (firstId != null)
			{
				dbNews = context.News
					.Join(context.News, n1 => (int)n1.Id, n2 => firstId.Value, (n1, n2) => new { n1, n2 })
					.Where(n => n.n1.Date >= n.n2.Date)
					.Select(n => n.n2)
					.Include(n => n.Tag)
					.Where(n => !n.NewsHidden)
					.OrderByDescending(n => n.Date);
			}
			else
			{
				dbNews = context.News
					.Where(n => !n.NewsHidden)
					.Include(n => n.Tag)
					.OrderByDescending(n => n.Date);
			}

			return GetPagedResult(dbNews, page, countPerPage);
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
								.FirstOrDefaultAsync(r => r.Date.Year == link.Year && r.Numinseason == link.Number))?
							.Id
					};
				}
			}
			return news;
		}

		public async Task<NewsSummaryPaged> GetNewsByTagId(int? tagId, int page, int countPerPage)
		{
			await SetDbEncoding();
			IQueryable<News> dbNews;

			dbNews = context.NewsTagMatch
					.Where(t => t.TagId == tagId)
					.Include(t => t.News)
					.Select(t => t.News)
					.Where(n => !n.NewsHidden)
					.Include(n => n.Tag);

			return GetPagedResult(dbNews, page, countPerPage);
		}

		public async Task<NewsSummaryPaged> GetNewsByTypeId(int? typeId, int page, int countPerPage)
		{
			await SetDbEncoding();
			IQueryable<News> dbNews;

			dbNews = context.News
				.Where(n => n.TypeId == typeId && !n.NewsHidden)
				.Include(n => n.Tag);

			return GetPagedResult(dbNews, page, countPerPage);
		}

		public async Task<IEnumerable<ApiModel.NewsType>> GetNewsTypes()
		{
			await SetDbEncoding();
			IEnumerable<DatabaseModel.NewsType> dbNewsTypes;
			dbNewsTypes = await context.NewsTypes.ToListAsync();
			return mapper.Map<IEnumerable<ApiModel.NewsType>>(dbNewsTypes);
		}

		public async Task<IEnumerable<ApiModel.NewsTag>> GetNewsTags()
		{
			await SetDbEncoding();
			IEnumerable<DatabaseModel.NewsTag> dbNewsTags;
			dbNewsTags = await context.NewsTopics.ToListAsync();
			return mapper.Map<IEnumerable<ApiModel.NewsTag>>(dbNewsTags);
		}

		public async Task<IEnumerable<ApiModel.NewsTag>> GetNewsTagsByCategoryId(int? categoryId)
		{
			await SetDbEncoding();
			IEnumerable<DatabaseModel.NewsTag> dbNewsTags;
			dbNewsTags = await context.NewsTopics.Where(nt => nt.CategoryId == categoryId).ToListAsync();
			return mapper.Map<IEnumerable<ApiModel.NewsTag>>(dbNewsTags);
		}

		public async Task<IEnumerable<ApiModel.NewsCategory>> GetNewsCategories()
		{
			await SetDbEncoding();
			IEnumerable<DatabaseModel.NewsCategory> dbCategories;
			dbCategories = await context.NewsCategories.ToListAsync();
			return mapper.Map<IEnumerable<ApiModel.NewsCategory>>(dbCategories);
		}

		public NewsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<bool> IncrementViews(int id)
		{
			await SetDbEncoding();
			var dbNews = await context.News
				.Where(n => n.Id == id)
				.FirstOrDefaultAsync();

			if (dbNews == null) return false;

			dbNews.Views++;
			context.Update(dbNews);
			await context.SaveChangesAsync();
			return true;
		}

		private NewsSummaryPaged GetPagedResult(IQueryable<News> dbNews, int page, int countPerPage)
		{
			var skipRows = (page - 1) * countPerPage;
			NewsSummaryPaged result = new NewsSummaryPaged
			{
				CurrentPage = page,
				RowCount = dbNews.Count()
			};

			var pageCount = (double)result.RowCount / countPerPage;
			result.PageCount = (int)System.Math.Ceiling(pageCount);

			dbNews = dbNews.OrderByDescending(n => n.Date)
					.Skip(skipRows)
					.Take(countPerPage);

			result.PageSize = dbNews.Count();
			result.Result = mapper.Map<IEnumerable<NewsSummary>>(dbNews);

			return result;
		}
	}
}
