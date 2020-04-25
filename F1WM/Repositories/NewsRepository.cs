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

		public Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, uint page, uint countPerPage)
		{
			IQueryable<News> dbNews;

			if (firstId != null)
			{
				var castFirstId = (uint)firstId.Value;
				dbNews = context.News
					.Join(context.News, n1 => n1.Id, n2 => castFirstId, (n1, n2) => new { n1, n2 })
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

			return dbNews.GetPagedResult<News, NewsSummary>(mapper, page, countPerPage);
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
				var newsTags = context.NewsTagMatches
					.Where(tm => tm.NewsId == id)
					.Select(t => t.Tag);
				news.RelatedTags = await mapper.ProjectTo<ApiModel.NewsTag>(newsTags).ToListAsync();
			}
			return news;
		}

		public Task<PagedResult<NewsSummary>> GetNewsByTagId(int tagId, uint page, uint countPerPage)
		{
			var dbNews = context.NewsTagMatches
					.Where(t => t.TagId == tagId)
					.Select(t => t.News)
					.Where(n => !n.NewsHidden)
					.OrderByDescending(n => n.Date);

			return dbNews.GetPagedResult<News, NewsSummary>(mapper, page, countPerPage);
		}

		public Task<PagedResult<NewsSummary>> GetNewsByTypeId(int typeId, uint page, uint countPerPage)
		{
			var dbNews = context.News
				.OrderByDescending(n => n.Date)
				.Where(n => n.TypeId == typeId && !n.NewsHidden);

			return dbNews.GetPagedResult<News, NewsSummary>(mapper, page, countPerPage);
		}

		public async Task<IEnumerable<ApiModel.NewsType>> GetNewsTypes()
		{
			var dbNewsTypes = context.NewsTypes;
			return await mapper.ProjectTo<ApiModel.NewsType>(dbNewsTypes).ToListAsync();
		}

		public Task<PagedResult<ApiModel.NewsTag>> GetNewsTags(uint page, uint countPerPage)
		{
			var dbNewsTags = context.NewsTags.OrderBy(nt => nt.Title);
			return dbNewsTags.GetPagedResult<DatabaseModel.NewsTag, ApiModel.NewsTag>(mapper, page, countPerPage);
		}

		public Task<PagedResult<ApiModel.NewsTag>> GetNewsTagsByCategoryId(int categoryId, uint page, uint countPerPage)
		{
			var dbNewsTags = context.NewsTags
				.Where(nt => nt.CategoryId == categoryId)
				.OrderBy(nt => nt.Id);
			return dbNewsTags.GetPagedResult<DatabaseModel.NewsTag, ApiModel.NewsTag>(mapper, page, countPerPage);
		}

		public async Task<IEnumerable<ApiModel.NewsTagCategory>> GetNewsTagCategories()
		{
			var dbCategories = context.NewsCategories.OrderBy(c => c.Id);
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

		public async Task<IEnumerable<NewsSummary>> GetRelatedNews(int newsId, DateTime before, int count)
		{
			var tagId = await context.News
				.Where(x => (int)x.Id == newsId)
				.Select(x=>x.MainTagId)
				.SingleAsync();
			
			var result = await mapper.ProjectTo<NewsSummary>(
					context.News
						.Where(x => x.Date < before
						            && x.MainTagId == tagId
						            && x.Id != newsId
						            && x.NewsHidden != true)
						.OrderByDescending(x => x.Date)
						.Take(count))
				.ToListAsync();
			
			return result.Count > 0 ? result : null;
		}

		public async Task<PagedResult<NewsSummary>> SearchNews(string term, uint page, uint countPerPage, DateTime before)
		{
			var result = context.News
				.Where(x => (x.Title.Like(term) || x.Subtitle.Like(term)) 
					&& x.Date < before
					&& !x.NewsHidden)
				.OrderByDescending(x => x.Date);

			return await result.GetPagedResult<News, NewsSummary>(mapper, page, countPerPage);
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
