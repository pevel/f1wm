using System.Collections.Generic;
using F1WM.Model;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		IEnumerable<NewsSummary> GetLatestNews(int? firstId = null, int? count = Constants.NewsCount);
		NewsDetails GetNewsDetails(int id);
	}
}