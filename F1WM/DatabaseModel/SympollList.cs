using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class SympollList
	{
		public uint Pid { get; set; }
		public uint Nextcid { get; set; }
		public string Question { get; set; }
		public uint TimeStamp { get; set; }
		public uint CookieStamp { get; set; }
		public ushort Status { get; set; }
	}
}