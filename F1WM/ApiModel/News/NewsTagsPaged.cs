using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.ApiModel
{
	public class NewsTagsPaged
	{
		public uint CurrentPage { get; set; }
		public uint PageCount { get; set; }
		public uint PageSize { get; set; }
		public uint RowCount { get; set; }
		public IEnumerable<NewsTag> Result { get; set; }
	}
}
