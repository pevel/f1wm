using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids);
		Task<NewsSummaryPaged> GetLatestNews(int? firstId, int page, int countPerPage);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<NewsSummaryPaged> GetNewsByTagId(int? tagId, int page, int countPerPage);
		Task<NewsSummaryPaged> GetNewsByTypeId(int? typeId, int page, int countPerPage);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<IEnumerable<NewsTag>> GetNewsTags();
		Task<IEnumerable<NewsTag>> GetNewsTagsByCategoryId(int? categoryId);
		Task<IEnumerable<NewsCategory>> GetNewsCategories();
	}
}