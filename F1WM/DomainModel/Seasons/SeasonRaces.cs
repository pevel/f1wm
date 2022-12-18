namespace F1WM.DomainModel
{
	public class SeasonRaces
	{
		public int Id { get; set; }
		public ushort Year { get; set; }
		public byte LastRaceNumber { get; set; }
		public byte RaceCount { get; set; }
	}
}
