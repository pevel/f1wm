using F1WM.DomainModel;

namespace F1WM.ApiModel
{
	public class DriverPosition : IStandingsPosition
	{
		public int Id { get; set; }
		public int Position { get; set; }
		public float Points { get; set; }
		public DriverSummary Driver { get; set; }
	}
}
