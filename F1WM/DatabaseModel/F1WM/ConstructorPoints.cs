namespace F1WM.DatabaseModel
{
	public class ConstructorPoints
	{
		public int Id { get; set; }
		public int RaceId { get; set; }
		public int SeasonId { get; set; }
		public int ConstructorId { get; set; }
		public int EngineMakeId { get; set; }
		public float? Points { get; set; }
		public float? NotCountedTowardsChampionshipPoints { get; set; }
		public virtual Race Race { get; set; }
		public virtual Season Season { get; set; }
		public virtual Constructor Constructor { get; set; }
		public virtual EngineMake EngineMake { get; set; }
	}
}
