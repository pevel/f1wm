using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<NewsSummaryPaged> GetLatestNews(int? firstId, uint page, uint countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<NewsSummaryPaged> GetNewsByTagId(int id, uint page, uint countPerPage);
		Task<NewsSummaryPaged> GetNewsByTypeId(int id, uint page, uint countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<NewsTagsPaged> GetNewsTags(uint page, uint countPerPage);
		Task<NewsTagsPaged> GetNewsTagsByCategoryId(int id, uint page, uint countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
		Task<bool> IncrementViews(int id);
	}
}
