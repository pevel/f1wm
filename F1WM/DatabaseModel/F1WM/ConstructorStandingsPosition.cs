namespace F1WM.DatabaseModel
{
	public class ConstructorStandingsPosition
	{
		public int Id { get; set; }
		public int SeasonId { get; set; }
		public int ConstructorId { get; set; }
		public int EngineMakeId { get; set; }
		public ushort Position { get; set; }
		public double Points { get; set; }
		public virtual Constructor Constructor { get; set; }
		public virtual Season Season { get; set; }
	}
}
