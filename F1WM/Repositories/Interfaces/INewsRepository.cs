using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId = null);
		Task<NewsDetails> GetNewsDetails(int id);
	}
}