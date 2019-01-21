using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<NewsSummaryPaged> GetLatestNews(int? firstId, int page, int countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<NewsSummaryPaged> GetNewsByTagId(int id, int page, int countPerPage);
		Task<NewsSummaryPaged> GetNewsByTypeId(int id, int page, int countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<NewsTagsPaged> GetNewsTags(int page, int countPerPage);
		Task<NewsTagsPaged> GetNewsTagsByCategoryId(int id, int page, int countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
		Task<bool> IncrementViews(int id);
	}
}
