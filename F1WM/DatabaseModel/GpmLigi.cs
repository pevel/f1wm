using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class GpmLigi
	{
		public uint Ligaid { get; set; }
		public uint Zalozycielid { get; set; }
		public uint Limitzespolow { get; set; }
		public uint Zespoly { get; set; }
		public uint Komentarze { get; set; }
		public string Nazwa { get; set; }
		public byte Zamknieta { get; set; }
		public uint Sumapkt { get; set; }
	}
}