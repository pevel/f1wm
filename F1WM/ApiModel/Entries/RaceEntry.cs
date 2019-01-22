namespace F1WM.ApiModel
{
	public class RaceEntry
	{
		public byte Number { get; set; }
		public EntryDriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public TyresSummary Tyres { get; set; }
		public EngineSummary Engine { get; set; }
		public TeamSummary Team { get; set; }
	}
}
