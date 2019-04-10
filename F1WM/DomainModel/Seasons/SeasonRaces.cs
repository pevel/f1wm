namespace F1WM.DomainModel
{
	public class SeasonRaces
	{
		public uint Id { get; set; }
		public ushort Year { get; set; }
		public byte	LastRaceNumber { get; set; }
		public byte RaceCount { get; set; }
	}
}
