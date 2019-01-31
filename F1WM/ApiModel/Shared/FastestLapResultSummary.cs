using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class FastestLapResultSummary : LapResultSummary
	{
		public CarSummary Car { get; set; }
		public int LapNumber { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public DateTime RaceDate { get; set; }
	}
}
