using System;

namespace F1WM.ApiModel
{
	public class Broadcast
	{
		public int Id { get; set; }
		public int BroadcastedSessionId { get; set; }
		public int BroadcasterId { get; set; }
		public DateTime Start { get; set; }
	}
}