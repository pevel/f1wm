using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, int page, int countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<PagedResult<NewsSummary>> GetNewsByTagId(int id, int page, int countPerPage);
		Task<PagedResult<NewsSummary>> GetNewsByTypeId(int id, int page, int countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<PagedResult<NewsTag>> GetNewsTags(int page, int countPerPage);
		Task<PagedResult<NewsTag>> GetNewsTagsByCategoryId(int id, int page, int countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
		Task<bool> IncrementViews(int id);
	}
}
