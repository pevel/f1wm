using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class NewsSummaryPaged
	{
		public uint CurrentPage { get; set; }
		public uint PageCount { get; set; }
		public uint PageSize { get; set; }
		public uint RowCount { get; set; }
		public IEnumerable<NewsSummary> Result { get; set; }
	}
}
