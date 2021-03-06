using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1ZgloszoneBledy
	{
		public string Id { get; set; }
		public DateTime Data { get; set; }
		public uint UserId { get; set; }
		public uint NewsId { get; set; }
		public uint ArtId { get; set; }
		public string Zglaszajacy { get; set; }
		public string OpisBledu { get; set; }
		public uint CommId { get; set; }
		public byte Typ { get; set; }
	}
}