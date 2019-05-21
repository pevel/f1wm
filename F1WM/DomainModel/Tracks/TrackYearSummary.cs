using F1WM.ApiModel;

namespace F1WM.DomainModel
{
	public class TrackYearSummary
	{
		public ushort Year { get; set; }
		public uint Id { get; set; }
		public uint RaceId { get; set; }
		public byte TrackVersion { get; set; }
	}
}
