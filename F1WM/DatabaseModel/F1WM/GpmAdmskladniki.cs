namespace F1WM.DatabaseModel
{
	public class GpmAdmskladniki
	{
		public int Id { get; set; }
		public byte Typ { get; set; }
		public string Ascid { get; set; }
		public string Nazwa { get; set; }
		public int Cena { get; set; }
		public int Wymuszona { get; set; }
		public byte Niestartuje { get; set; }
		public int Idmodelu { get; set; }
		public string Staryzespol { get; set; }
		public string Kierzesp { get; set; }
		public byte Nrstart { get; set; }
	}
}