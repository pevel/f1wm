using System.Threading.Tasks;
using F1WM.ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	public interface IAcceptingFilters<T>
	{
		Task<ActionResult<SearchResult<T>>> Search(string filter, int page, int countPerPage);
	}
}
