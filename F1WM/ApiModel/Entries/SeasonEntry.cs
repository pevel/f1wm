namespace F1WM.ApiModel
{
	public class SeasonEntry
	{
		public byte Number { get; set; }
		public bool IsThirdDriver { get; set; }
		public EntryDriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
		public TeamSummary Team { get; set; }
	}
}
