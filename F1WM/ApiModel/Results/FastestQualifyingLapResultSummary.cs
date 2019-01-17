using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class FastestQualifyingLapResultSummary : LapResultSummary
	{
		public CarSummary Car { get; set; }
		public DateTime RaceDate { get; set; }
	}
}
