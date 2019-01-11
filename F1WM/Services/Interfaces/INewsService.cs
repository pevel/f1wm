using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId);
		Task<NewsDetails> GetNewsDetails(int id);
        Task<IEnumerable<NewsSummary>> GetNewsByTag(int id);
        Task<IEnumerable<NewsSummary>> GetNewsByType(int id);
        Task<IEnumerable<NewsType>> GetNewsTypes();
        Task<IEnumerable<NewsTag>> GetNewsTags();
        Task<IEnumerable<NewsTag>> GetNewsTagsByCategory(int id);    
        Task<IEnumerable<NewsCategory>> GetNewsCategories();
        Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
	}
}