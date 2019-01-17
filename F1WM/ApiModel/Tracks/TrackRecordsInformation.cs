namespace F1WM.ApiModel
{
	public class TrackRecordsInformation
	{
		public int TrackId { get; set; }
		public int TrackVersion { get; set; }
		public int BeforeYear { get; set; }
		public FastestQualifyingLapResultSummary FastestQualifyingLapResult { get; set; }
		public FastestLapResultSummary FastestRaceLapResult { get; set; }
		public AverageSpeedResult BestAverageSpeedResult { get; set; }
	}
}
