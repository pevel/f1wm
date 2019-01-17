using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class SympollAuth
	{
		public int Uid { get; set; }
		public string User { get; set; }
		public string Pass { get; set; }
		public ushort Access { get; set; }
		public string Secret { get; set; }
	}
}