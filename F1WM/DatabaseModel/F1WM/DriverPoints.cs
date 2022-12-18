namespace F1WM.DatabaseModel
{
	public class DriverPoints
	{
		public int Id { get; set; }
		public int RaceId { get; set; }
		public int SeasonId { get; set; }
		public int DriverId { get; set; }
		public float? Points { get; set; }
		public float? NotCountedTowardsChampionshipPoints { get; set; }
		public virtual Driver Driver { get; set; }
		public virtual Season Season { get; set; }
		public virtual Race Race { get; set; }
		public virtual Entry Entry { get; set; }
	}
}
