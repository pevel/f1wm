using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class ConstructorPositionAfterRace : ConstructorPosition
	{
		public int Change { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? NotCountedTowardsChampionshipPoints { get; set; }
	}
}
