using F1WM.ApiModel;

namespace F1WM.Repositories.Statistics.Model
{
	public class CarsSeason
	{
		public uint SeasonId { get; set; }
		public CarSummary Car { get; set; }
	}
}
