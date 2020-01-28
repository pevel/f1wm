using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Utilities
{
	public static class IQueryableExtensions
	{
		public static async Task<PagedResult<TResult>> GetPagedResult<TSource, TResult>(
			this IQueryable<TSource> source,
			IMapper mapper,
			uint page,
			uint countPerPage)
		{
			page = page == 0 ? 1 : page;
			var skipRows = (page - 1) * countPerPage;
			PagedResult<TResult> pagedResult = new PagedResult<TResult>
			{
				CurrentPage = page,
				RowCount = (uint)source.Count()
			};

			var pageCount = (double)pagedResult.RowCount / countPerPage;
			pagedResult.PageCount = (uint)System.Math.Ceiling(pageCount);

			var apiResult = await mapper.ProjectTo<TResult>(source
					.Skip((int)skipRows)
					.Take((int)countPerPage))
				.ToListAsync();

			pagedResult.PageSize = (uint)apiResult.Count();
			pagedResult.Result = apiResult;

			return pagedResult;
		}

		public static async Task<SearchResult<TResult>> GetSearchResult<TSource, TResult>(
			this IQueryable<TSource> source,
			IMapper mapper,
			uint page,
			uint countPerPage)
		{
			var pagedResult = await source.GetPagedResult<TSource, TResult>(mapper, page, countPerPage);
			return new SearchResult<TResult>()
			{
				CurrentPage = pagedResult.CurrentPage,
				PageSize = pagedResult.PageSize,
				PageCount = pagedResult.PageSize,
				RowCount = pagedResult.RowCount,
				Result = pagedResult.Result
			};
		}
	}
}
