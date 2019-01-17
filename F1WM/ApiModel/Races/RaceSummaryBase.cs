using System;

namespace F1WM.ApiModel
{
	public class RaceSummaryBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string TranslatedName { get; set; }
		public DateTime Date { get; set; }
		public TrackSummary Track { get; set; }
	}
}