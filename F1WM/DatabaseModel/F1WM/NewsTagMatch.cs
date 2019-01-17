using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class NewsTagMatch
	{
		public uint Id { get; set; }
		public uint NewsId { get; set; }
		public uint TagId { get; set; }
		public DateTime NewsDate { get; set; }
		public virtual News News { get; set; }
	}
}
