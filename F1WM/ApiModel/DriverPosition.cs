namespace F1WM.ApiModel
{
	public class DriverPosition
	{
		public int Id { get; set; }
		public int Position { get; set; }
		public double Points { get; set; }
		public string DriverName { get; set; }
		public Nationality Nationality { get; set; }
	}
}