using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class PagedResult<T>
	{
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }
		public int PageSize { get; set; }
		public int RowCount { get; set; }
		public IEnumerable<T> Result { get; set; }
	}
}
