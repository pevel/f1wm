using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class BroadcastedSession
	{
		public int Id { get; set; }
		public string TypeName { get; set; }
		public DateTime Start { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<Broadcast> Broadcasts { get; set; }
	}
}
