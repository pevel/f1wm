using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class GpmAdmskladniki
	{
		public uint Id { get; set; }
		public byte Typ { get; set; }
		public string Ascid { get; set; }
		public string Nazwa { get; set; }
		public uint Cena { get; set; }
		public uint Wymuszona { get; set; }
		public byte Niestartuje { get; set; }
		public uint Idmodelu { get; set; }
		public string Staryzespol { get; set; }
		public string Kierzesp { get; set; }
		public byte Nrstart { get; set; }
	}
}