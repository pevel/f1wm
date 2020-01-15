using System.Collections.Generic;
using System.Linq;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class BroadcastsExtensions
	{
		public static IEnumerable<Broadcaster> GetBroadcasters(this IEnumerable<BroadcastedSession> sessions)
		{
			var broadcasts = sessions.SelectMany(s => s.Broadcasts);
			var broadcasters = broadcasts
				.Select(b => b.Broadcaster)
				.GroupBy(b => b.Id)
				.Select(x => x.First());
			return broadcasters.Select(broadcaster => new Broadcaster()
			{
				Id = broadcaster.Id,
				Url = broadcaster.Url,
				Name = broadcaster.Name,
				Icon = broadcaster.Icon,
				Broadcasts = broadcasts.Where(broadcast => broadcast.BroadcasterId == broadcaster.Id)
			});
		}
	}
}
