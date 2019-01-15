using System;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class EntryExtensions
	{
		public static TimeSpan GetLapTime(this Entry entry)
		{
			return entry.Grid != null ? entry.Grid.Time : entry.FastestLap.Time;
		}

		public static StartStatus GetStartStatus(this Entry entry)
		{
			if (entry.Grid != null && entry.Grid.StartPosition != null)
			{
				return entry.Grid.StartStatus.GetStartStatus();
			}
			else
			{
				return StartStatus.DidNotStart;
			}
		}
	}
}
