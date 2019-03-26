using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class DriversStandingsAfterRace
	{
		public int RaceId { get; set; }
		public IEnumerable<DriverPositionAfterRace> Positions { get; set; }
	}
}
