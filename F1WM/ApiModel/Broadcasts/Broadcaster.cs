using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class Broadcaster
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<Broadcast> Broadcasts { get; set; }
	}
}