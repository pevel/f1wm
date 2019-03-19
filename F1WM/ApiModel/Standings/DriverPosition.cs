namespace F1WM.ApiModel
{
	public class DriverPosition
	{
		public int Id { get; set; }
		public int Position { get; set; }
		public float Points { get; set; }
		public DriverSummary Driver { get; set; }
	}
}
