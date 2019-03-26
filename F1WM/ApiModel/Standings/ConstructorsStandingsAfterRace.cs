using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class ConstructorsStandingsAfterRace
	{
		public int RaceId { get; set; }
		public IEnumerable<ConstructorPositionAfterRace> Positions { get; set; }
	}
}
