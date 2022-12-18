namespace F1WM.DatabaseModel
{
	public class Entry
	{
		public int Id { get; set; }
		public int RaceId { get; set; }
		public byte Number { get; set; }
		public int DriverId { get; set; }
		public int TeamId { get; set; }
		public int TeamNameId { get; set; }
		public int CarId { get; set; }
		public int CarMakeId { get; set; }
		public int EngineId { get; set; }
		public int EngineMakeId { get; set; }
		public int TyresId { get; set; }
		public bool IsThirdDriver { get; set; }
		public virtual Driver Driver { get; set; }
		public virtual Grid Grid { get; set; }
		public virtual Result Result { get; set; }
		public virtual Race Race { get; set; }
		public virtual FastestLap FastestLap { get; set; }
		public virtual Car Car { get; set; }
		public virtual Tyres Tyres { get; set; }
		public virtual Qualifying Qualifying { get; set; }
		public virtual Engine Engine { get; set; }
		public virtual Team Team { get; set; }
		public virtual TeamName TeamName { get; set; }
	}
}
