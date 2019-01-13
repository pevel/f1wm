using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId);
		Task<NewsDetails> GetNewsDetails(int id);
        Task<IEnumerable<NewsSummary>> GetNewsByTagId(int? id, int page,int countPerPage);
        Task<IEnumerable<NewsSummary>> GetNewsByTypeId(int? id, int page, int countPerPage);
        Task<IEnumerable<NewsType>> GetNewsTypes();
        Task<IEnumerable<NewsTag>> GetNewsTags();
        Task<IEnumerable<NewsTag>> GetNewsTagsByCategoryId(int? id);    
        Task<IEnumerable<NewsCategory>> GetNewsCategories();
        Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
	}
}