using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class EngineDetails : EngineSummary
	{
		public string Logo { get; set; }
		public RaceSummary FirstStartAt { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public RaceSummary FirstWinAt { get; set; }
		public Dictionary<string, string> Specifications { get; set; }
	}
}
