using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids);
		Task<NewsSummaryPaged> GetLatestNews(int? firstId, uint page, uint countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<NewsSummaryPaged> GetNewsByTagId(int tagId, uint page, uint countPerPage);
		Task<NewsSummaryPaged> GetNewsByTypeId(int typeId, uint page, uint countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<NewsTagsPaged> GetNewsTags(uint page, uint countPerPage);
		Task<NewsTagsPaged> GetNewsTagsByCategoryId(int categoryId, uint page, uint countPerPage);
		Task<IEnumerable<NewsTagCategory>> GetNewsTagCategories();
		Task<bool> IncrementViews(int id);
	}
}
