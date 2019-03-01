using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class FastestLapResultSummary : FastestLapResultBase
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? RaceDate { get; set; }
	}
}
