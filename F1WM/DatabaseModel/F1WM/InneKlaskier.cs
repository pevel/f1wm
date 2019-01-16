using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class InneKlaskier
	{
		public uint Id { get; set; }
		public uint Kierowcaid { get; set; }
		public uint Seriaid { get; set; }
		public string Sezon { get; set; }
		public byte Pozycja { get; set; }
		public byte Mistrz { get; set; }
		public string Klasa { get; set; }
	}
}