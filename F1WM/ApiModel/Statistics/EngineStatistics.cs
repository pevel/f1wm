using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class EngineStatistics
	{
		public int EngineId { get; set; }
		public IEnumerable<EngineSeason> Seasons { get; set; }
	}
}
