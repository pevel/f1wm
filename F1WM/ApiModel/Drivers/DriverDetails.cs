using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class DriverDetails : DriverSummary
	{
		public DateTime Birthday { get; set; }
		public string BirthPlace { get; set; }
		public string Residence { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string DeathPlace { get; set; }
		public string Website { get; set; }
		public int Height { get; set; }
		public int Weight { get; set; }
		public string MaritalStatus { get; set; }
		public string Kids { get; set; }
		public int TotalPoints { get; set; }
		public int Number { get; set; }
		public TeamSummary CurrentTeam { get; set; }
		public CarSummary CurrentCar { get; set; }
		public int Starts { get; set; }
		public int Wins { get; set; }
		public int PolePositions { get; set; }
		public int FastestLaps { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<int> WorldChampionAtYears { get; set; }
		public DriverDetailsRaceSummary FirstStartAt { get; set; }
		public DriverDetailsRaceSummary FirstWinAt { get; set; }
		public IEnumerable<DriverCareerYear> Career { get; set; }
	}
}
