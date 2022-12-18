namespace F1WM.DatabaseModel
{
	public class DriverStandingsPosition
	{
		public int Id { get; set; }
		public int SeasonId { get; set; }
		public int DriverId { get; set; }
		public ushort Position { get; set; }
		public double Points { get; set; }
		public virtual Driver Driver { get; set; }
		public virtual Season Season { get; set; }
	}
}
