using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		Task<IEnumerable<NewsSummary>> GetNews(ICollection<uint> ids);
		Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId);
		Task<NewsDetails> GetNewsDetails(int id);
		Task<bool> IncrementViews(int id);
	}
}
