using F1WM.ApiModel;

namespace F1WM.Repositories.Statistics.Model
{
	public class TeamsSeason
	{
		public int SeasonId { get; set; }
		public TeamSummary Team { get; set; }
	}
}
