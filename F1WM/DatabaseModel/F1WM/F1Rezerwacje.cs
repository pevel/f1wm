using System;

namespace F1WM.DatabaseModel
{
	public class F1Rezerwacje
	{
		public string Id { get; set; }
		public string Tytul { get; set; }
		public string Linki { get; set; }
		public DateTime Datadod { get; set; }
		public DateTime Datarez { get; set; }
		public int Redaktor { get; set; }
		public byte Status { get; set; }
		public byte Pilne { get; set; }
		public int Rsscrc { get; set; }
		public string Notatki { get; set; }
		public int Zglaszajacy { get; set; }
		public int Newsid { get; set; }
	}
}