using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class DriverPositionAfterRace : DriverPosition
	{
		public int Change { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? NotCountedTowardsChampionshipPoints { get; set; }
	}
}
