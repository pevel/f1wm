using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Season
	{
		public uint Id { get; set; }
		public ushort Year { get; set; }
		public byte Races { get; set; }
		public byte Lastrace { get; set; }
		public string Reviewnews { get; set; }
		public string Reviewarts { get; set; }
		public string Pointssystem { get; set; }
		public string Enginerules { get; set; }
		public string Carweight { get; set; }
		public string Qualrules { get; set; }
		public uint Newstyres { get; set; }
	}
}
