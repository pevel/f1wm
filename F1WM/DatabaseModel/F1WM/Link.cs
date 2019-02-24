using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Link
	{
		public uint Id { get; set; }
		public string Url { get; set; }
		public uint LCatgrp { get; set; }
		public string CategoryKey { get; set; }
		public string LNazwa { get; set; }
		public string LOpis { get; set; }
		public string LJezyki { get; set; }
		public DateTime LData { get; set; }
		public byte LOcena { get; set; }
		public uint LOdslony { get; set; }
		public byte Status { get; set; }
		public string LBanurl { get; set; }
		public byte LRotator { get; set; }
	}
}
