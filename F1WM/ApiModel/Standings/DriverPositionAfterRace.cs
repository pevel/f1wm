namespace F1WM.ApiModel
{
	public class DriverPositionAfterRace : DriverPosition
	{
		public int Change { get; set; }
		public float? NotCountedTowardsChampionshipPoints { get; set; }
	}
}
