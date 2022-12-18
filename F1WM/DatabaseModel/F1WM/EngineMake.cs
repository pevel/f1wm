namespace F1WM.DatabaseModel
{
	public class EngineMake
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Name { get; set; }
		public string NationalityKey { get; set; }
		public byte Status { get; set; }
		public string Letter { get; set; }
		public Country Country { get; set; }
	}
}
