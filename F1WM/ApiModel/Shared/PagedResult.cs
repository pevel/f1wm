using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class PagedResult<T>
	{
		public uint CurrentPage { get; set; }
		public uint PageCount { get; set; }
		public uint PageSize { get; set; }
		public uint RowCount { get; set; }
		public IEnumerable<T> Result { get; set; }
	}
}
