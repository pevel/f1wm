using System;

namespace F1WM.DatabaseModel
{
	public class GpmLigiKoms
	{
		public int Komid { get; set; }
		public int Ligaid { get; set; }
		public int Zespolid { get; set; }
		public DateTime Czas { get; set; }
		public byte Status { get; set; }
		public string Autor { get; set; }
		public string Tresc { get; set; }
	}
}