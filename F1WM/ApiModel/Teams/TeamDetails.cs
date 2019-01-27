using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class TeamDetails : TeamSummary
	{
		public string Headquarters { get; set; }
		public string Website { get; set; }
		public Management Management { get; set; }
		public IEnumerable<DriverSummary> TestDrivers { get; set; }
		public RaceSummary FirstStartAt { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public RaceSummary FirstWinAt { get; set; }
		public CarSummary Car { get; set; }
		public Country Country { get; set; }
	}
}
