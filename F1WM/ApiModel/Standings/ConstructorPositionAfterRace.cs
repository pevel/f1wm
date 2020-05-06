using F1WM.DomainModel;

namespace F1WM.ApiModel
{
	public class ConstructorPositionAfterRace : ConstructorPosition, IStandingsPosition
	{
		public int Change { get; set; }
		public float NotCountedTowardsChampionshipPoints { get; set; }
	}
}
