using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class SeasonEntriesInformation
	{
		public SeasonSummary Season { get; set; }
		public IEnumerable<SeasonEntry> Entries { get; set; }
	}
}
