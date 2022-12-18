using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<int> ids);
		Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, int page, int countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<PagedResult<NewsSummary>> GetNewsByTagId(int tagId, int page, int countPerPage);
		Task<PagedResult<NewsSummary>> GetNewsByTypeId(int typeId, int page, int countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<PagedResult<NewsTag>> GetNewsTags(int page, int countPerPage);
		Task<PagedResult<NewsTag>> GetNewsTagsByCategoryId(int categoryId, int page, int countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<bool> IncrementViews(int id);
		Task<IEnumerable<NewsSummary>> GetRelatedNews(int newsId, DateTime before, int count);
		Task<PagedResult<NewsSummary>> SearchNews(string term, int page, int countPerPage, DateTime before);
	}
}
