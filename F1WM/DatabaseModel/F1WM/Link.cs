using System;

namespace F1WM.DatabaseModel
{
	public class Link
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public int LCatgrp { get; set; }
		public string CategoryKey { get; set; }
		public string LNazwa { get; set; }
		public string LOpis { get; set; }
		public string LJezyki { get; set; }
		public DateTime LData { get; set; }
		public byte LOcena { get; set; }
		public int LOdslony { get; set; }
		public byte Status { get; set; }
		public string LBanurl { get; set; }
		public byte LRotator { get; set; }
	}
}
