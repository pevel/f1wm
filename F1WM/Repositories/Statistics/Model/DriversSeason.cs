using F1WM.ApiModel;

namespace F1WM.Repositories.Statistics.Model
{
	public class DriversSeason
	{
		public uint SeasonId { get; set; }
		public DriverSummary Driver { get; set; }
	}
}
