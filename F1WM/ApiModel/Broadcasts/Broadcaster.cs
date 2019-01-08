using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class Broadcaster
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public IEnumerable<SessionBroadcastSummary> SessionBroadcasts { get; set; }
	}
}