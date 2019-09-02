
using System;
using System.Linq.Expressions;

namespace F1WM.Services
{
	public interface ISearchService
	{
		Expression<Func<T, bool>> BuildExpressionFrom<T>(string filter);
	}
}
