using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class TeamStatistics
	{
		public int TeamId { get; set; }
		public IEnumerable<TeamSeason> Seasons { get; set; }
	}
}
