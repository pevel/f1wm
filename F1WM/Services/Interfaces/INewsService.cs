using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, uint page, uint countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<PagedResult<NewsSummary>> GetNewsByTagId(int id, uint page, uint countPerPage);
		Task<PagedResult<NewsSummary>> GetNewsByTypeId(int id, uint page, uint countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<PagedResult<NewsTag>> GetNewsTags(uint page, uint countPerPage);
		Task<PagedResult<NewsTag>> GetNewsTagsByCategoryId(int id, uint page, uint countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
		Task<bool> IncrementViews(int id);
		Task<IEnumerable<NewsSummary>> GetRelatedNews(int newsId, DateTime? before, int? count);
	}
}
