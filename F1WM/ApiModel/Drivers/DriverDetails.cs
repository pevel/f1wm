using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class DriverDetails : DriverSummary
	{
		public string Picture { get; set; }
		public DateTime Birthday { get; set; }
		public string BirthPlace { get; set; }
		public string Residence { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string DeathPlace { get; set; }
		public string Website { get; set; }
		public string Height { get; set; }
		public string Weight { get; set; }
		public string MaritalStatus { get; set; }
		public string Kids { get; set; }
		public int Number { get; set; }
		public TeamSummary Team { get; set; }
		public CarSummary Car { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<ushort> F1ChampionAtYears { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<string> ChampionAtSeries { get; set; }
		public RaceSummary FirstStartAt { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public RaceSummary FirstWinAt { get; set; }
		public IEnumerable<DriverCareerPeriod> CareerPeriods { get; set; }
	}
}
