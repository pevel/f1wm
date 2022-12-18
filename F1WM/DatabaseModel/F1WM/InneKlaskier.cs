namespace F1WM.DatabaseModel
{
	public class InneKlaskier
	{
		public int Id { get; set; }
		public int Kierowcaid { get; set; }
		public int Seriaid { get; set; }
		public string Sezon { get; set; }
		public byte Pozycja { get; set; }
		public byte Mistrz { get; set; }
		public string Klasa { get; set; }
	}
}