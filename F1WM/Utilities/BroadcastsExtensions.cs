using System.Collections.Generic;
using System.Linq;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class BroadcastsExtensions
	{
		public static IEnumerable<Broadcaster> GetBroadcasters(this IEnumerable<BroadcastedSession> sessions)
		{
			var broadcasters = sessions
				.SelectMany(s => s.Broadcasts)
				.Select(b => b.Broadcaster)
				.GroupBy(b => b.Id)
				.Select(x => x.First());
			return broadcasters;
		}
	}
}
