namespace F1WM.ApiModel
{
	public class FastestLapResultBase : LapResultSummary
	{
		public CarSummary Car { get; set; }
		public byte LapNumber { get; set; }
	}
}
