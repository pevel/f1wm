using System.Collections.Generic;
using F1WM.Model;

namespace F1WM.Repositories
{
	public interface INewsRepository
	{
		IEnumerable<News> GetNews(int? firstId = null, int? count = 20);
	}
}