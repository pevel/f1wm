using F1WM.ApiModel;

namespace F1WM.Repositories.Statistics.Model
{
	public class TeamsSeason
	{
		public uint SeasonId { get; set; }
		public TeamSummary Team { get; set; }
	}
}
