using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1Arts
	{
		public uint Artid { get; set; }
		public uint Catid { get; set; }
		public uint Newsid { get; set; }
		public string Arttitle { get; set; }
		public string Artposter { get; set; }
		public byte Arthidden { get; set; }
		public uint Artviews { get; set; }
		public string Artpreview { get; set; }
		public string Arttext { get; set; }
	}
}