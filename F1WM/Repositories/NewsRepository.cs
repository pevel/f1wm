using System;
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
			var dbNews = context.News.Where(n => ids.Contains(n.Id));
			return await mapper.ProjectTo<NewsSummary>(dbNews).ToListAsync();
		}

		public async Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, uint page, uint countPerPage)
		{
			IQueryable<News> dbNews;

			if (firstId != null)
			{
				dbNews = context.News
					.Join(context.News, n1 => (int)n1.Id, n2 => firstId.Value, (n1, n2) => new { n1, n2 })
					.Where(n => n.n1.Date >= n.n2.Date)
					.Select(n => n.n2)
					.Include(n => n.MainTag)
					.Where(n => !n.NewsHidden)
					.OrderByDescending(n => n.Date);
			}
			else
			{
				dbNews = context.News
					.Where(n => !n.NewsHidden)
					.Include(n => n.MainTag)
					.OrderByDescending(n => n.Date);
			}

			return await GetPagedNewsResult(dbNews, page, countPerPage);
		}

		public async Task<NewsDetails> GetNewsDetails(int id)
		{
			var dbNews = context.News.Where(n => n.Id == id && !n.NewsHidden);
			var news = await mapper.ProjectTo<NewsDetails>(dbNews).FirstOrDefaultAsync();
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
				if (news.Redirect != null && news.TryParseResultRedirect(out ResultRedirectLink link))
				{
					await IncludeResultLink(news, link);
				}
			}
			return news;
		}

		public async Task<PagedResult<NewsSummary>> GetNewsByTagId(int tagId, uint page, uint countPerPage)
		{
			var dbNews = context.NewsTagMatches
					.Where(t => t.TagId == tagId)
					.Include(t => t.News)
					.Select(t => t.News)
					.Where(n => !n.NewsHidden)
					.Include(n => n.MainTag);

			return await GetPagedNewsResult(dbNews, page, countPerPage);
		}

		public async Task<PagedResult<NewsSummary>> GetNewsByTypeId(int typeId, uint page, uint countPerPage)
		{
			var dbNews = context.News
				.Where(n => n.TypeId == typeId && !n.NewsHidden)
				.Include(n => n.MainTag);

			return await GetPagedNewsResult(dbNews, page, countPerPage);
		}

		public async Task<IEnumerable<ApiModel.NewsType>> GetNewsTypes()
		{
			var dbNewsTypes = context.NewsTypes;
			return await mapper.ProjectTo<ApiModel.NewsType>(dbNewsTypes).ToListAsync();
		}

		public async Task<PagedResult<ApiModel.NewsTag>> GetNewsTags(uint page, uint countPerPage)
		{
			var dbNewsTags = context.NewsTags;
			return await GetPagedTagsResult(dbNewsTags, page, countPerPage);
		}

		public async Task<PagedResult<ApiModel.NewsTag>> GetNewsTagsByCategoryId(int categoryId, uint page, uint countPerPage)
		{
			var dbNewsTags = context.NewsTags.Where(nt => nt.CategoryId == categoryId);
			return await GetPagedTagsResult(dbNewsTags, page, countPerPage);
		}

		public async Task<IEnumerable<ApiModel.NewsTagCategory>> GetNewsTagCategories()
		{
			var dbCategories = context.NewsCategories;
			return await mapper.ProjectTo<ApiModel.NewsTagCategory>(dbCategories).ToListAsync();
		}

		public NewsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<bool> IncrementViews(int id)
		{
			var dbNews = await context.News
				.Where(n => n.Id == id)
				.FirstOrDefaultAsync();

			if (dbNews == null) return false;

			dbNews.Views++;
			context.Update(dbNews);
			await context.SaveChangesAsync();
			return true;
		}

		private async Task<PagedResult<NewsSummary>> GetPagedNewsResult(IQueryable<News> dbNews, uint page, uint countPerPage)
		{
			var skipRows = (page - 1) * countPerPage;
			PagedResult<NewsSummary> result = new PagedResult<NewsSummary>
			{
				CurrentPage = page,
				RowCount = (uint)dbNews.Count()
			};

			var pageCount = (double)result.RowCount / countPerPage;
			result.PageCount = (uint)System.Math.Ceiling(pageCount);

			var apiNews = await mapper.ProjectTo<NewsSummary>(
				dbNews.OrderByDescending(n => n.Date)
					.Skip((int)skipRows)
					.Take((int)countPerPage))
				.ToListAsync();

			result.PageSize = (uint)apiNews.Count();
			result.Result = apiNews;

			return result;
		}

		private async Task<PagedResult<ApiModel.NewsTag>> GetPagedTagsResult(IQueryable<DatabaseModel.NewsTag> dbNewsTags, uint page, uint countPerPage)
		{
			var skipRows = (page - 1) * countPerPage;
			PagedResult<ApiModel.NewsTag> result = new PagedResult<ApiModel.NewsTag>
			{
				CurrentPage = page,
				RowCount = (uint)dbNewsTags.Count()
			};

			var pageCount = (double)result.RowCount / countPerPage;
			result.PageCount = (uint)System.Math.Ceiling(pageCount);

			var apiTags = await mapper.ProjectTo<ApiModel.NewsTag>(
				dbNewsTags
					.Skip((int)skipRows)
					.Take((int)countPerPage))
				.ToListAsync();

			result.PageSize = (uint)apiTags.Count();
			result.Result = apiTags;

			return result;
		}

		private async Task IncludeResultLink(NewsDetails news, ResultRedirectLink link)
		{
			var resultType = Constants.ResultTypeToLinkType[link.ResultType];
			if (Constants.LinkTypeToAction.TryGetValue(resultType, out var getLink))
			{
				news.ResultLink = await getLink(context, link);
			}
			else
			{
				throw new NotImplementedException();
			}
		}
	}
}
