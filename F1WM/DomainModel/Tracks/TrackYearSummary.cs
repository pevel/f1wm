namespace F1WM.DomainModel
{
	public class TrackYearSummary
	{
		public ushort Year { get; set; }
		public int Id { get; set; }
		public int RaceId { get; set; }
		public byte TrackVersion { get; set; }
	}
}
