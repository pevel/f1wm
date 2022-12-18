namespace F1WM.DatabaseModel
{
	public class InneRezultatyBk
	{
		public int Id { get; set; }
		public int Imprezaid { get; set; }
		public ushort Okrazenia { get; set; }
		public double Czas { get; set; }
		public byte Pozycja { get; set; }
		public string Status { get; set; }
		public int Zgloszenieid { get; set; }
		public ushort Dodpktza { get; set; }
		public byte Pozklasa { get; set; }
	}
}