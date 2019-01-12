using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface INewsService
	{
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<IEnumerable<ImportantNewsSummary>> GetImportantNews();
		Task<bool> IncrementViews(int id);
	}
}
