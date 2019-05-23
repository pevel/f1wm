using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids);
		Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, uint page, uint countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<PagedResult<NewsSummary>> GetNewsByTagId(int tagId, uint page, uint countPerPage);
		Task<PagedResult<NewsSummary>> GetNewsByTypeId(int typeId, uint page, uint countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<PagedResult<NewsTag>> GetNewsTags(uint page, uint countPerPage);
		Task<PagedResult<NewsTag>> GetNewsTagsByCategoryId(int categoryId, uint page, uint countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<bool> IncrementViews(int id);
		Task<IEnumerable<NewsSummary>> GetRelatedNews(int newsId, DateTime before, int count);
		Task<PagedResult<NewsSummary>> SearchNews(string term, DateTime before, uint page, uint countPerPage);
	}
}
