using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1Redakcja
	{
		public uint Id { get; set; }
		public string N { get; set; }
		public string Email { get; set; }
		public string Funkcja { get; set; }
		public byte Grupa { get; set; }
		public string Informacje { get; set; }
		public byte L { get; set; }
		public byte Korekta { get; set; }
		public byte Modkom { get; set; }
		public byte F1db { get; set; }
		public byte Isdb { get; set; }
		public byte Ligna { get; set; }
		public uint Userid { get; set; }
		public string Portret { get; set; }
		public string Www { get; set; }
		public byte Tylkoligna { get; set; }
		public byte Gpm { get; set; }
		public string Skroty { get; set; }
	}
}