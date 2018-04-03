using System.Collections.Generic;
using F1WM.Model;

namespace F1WM.Services
{
	public interface INewsService
	{
		IEnumerable<NewsSummary> GetLatestNews(int count, int? firstId);
		NewsDetails GetNewsDetails(int id);
	}
}