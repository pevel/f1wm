using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids);
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId = null);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<IEnumerable<NewsSummary>> GetNewsByTagId(int? tagId, int page = 1, int countPerPage = 20);
		Task<IEnumerable<NewsSummary>> GetNewsByTypeId(int? typeId, int page = 1, int countPerPage = 20);
		Task<IEnumerable<NewsType>> GetNewsTypes();
		Task<IEnumerable<NewsTag>> GetNewsTags();
		Task<IEnumerable<NewsTag>> GetNewsTagsByCategoryId(int? categoryId);
		Task<IEnumerable<NewsCategory>> GetNewsCategories();
	}
}