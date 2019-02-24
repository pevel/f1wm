using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class GridInformation
	{
		public int RaceId { get; set; }
		public int GridTypeId { get; set; }
		public IEnumerable<GridPosition> GridPositions { get; set; }
	}
}
