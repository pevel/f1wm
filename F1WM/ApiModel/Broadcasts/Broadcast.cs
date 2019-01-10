using System;

namespace F1WM.ApiModel
{
	public class Broadcast
	{
		public int Id { get; set; }
		public int SessionId { get; set; }
		public int BroadcasterId { get; set; }
		public DateTime Start { get; set; }
	}
}