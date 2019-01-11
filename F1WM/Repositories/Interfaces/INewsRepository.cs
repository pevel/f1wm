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
        Task<IEnumerable<NewsSummary>> GetNewsByTag(int id);
        Task<IEnumerable<NewsSummary>> GetNewsByType(int id);
        Task<IEnumerable<NewsType>> GetNewsTypes();
        Task<IEnumerable<NewsTag>> GetNewsTags();
        Task<IEnumerable<NewsTag>> GetNewsTagsByCategory(int id);
        Task<IEnumerable<NewsCategory>> GetNewsCategories();
    }
}