using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class DriverStatistics
	{
		public int DriverId { get; set; }
		public IEnumerable<DriverSeason> Seasons { get; set; }
	}
}
