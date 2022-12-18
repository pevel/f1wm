using F1WM.ApiModel;

namespace F1WM.Repositories.Statistics.Model
{
	public class CarsSeason
	{
		public int SeasonId { get; set; }
		public CarSummary Car { get; set; }
	}
}
