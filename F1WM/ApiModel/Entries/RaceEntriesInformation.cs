using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceEntriesInformation
	{
		public int RaceId { get; set; }
		public IEnumerable<RaceEntry> Entries { get; set; }
	}
}
