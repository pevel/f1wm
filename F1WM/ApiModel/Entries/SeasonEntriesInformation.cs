using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class SeasonEntriesInformation
	{
		public int SeasonYear { get; set; }
		public IEnumerable<SeasonEntry> Entries { get; set; }
	}
}
