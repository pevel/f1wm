using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ISearching<T>
	{
		Task<PagedResult<T>> Search(string filter, int page, int countPerPage);
	}
}
