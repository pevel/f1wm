namespace F1WM.ApiModel
{
	public class TrackRaceSummary : RaceSummary
	{
		public int Laps { get; set; }
		public byte OrderInSeason { get; set; }
		public string TranslatedName { get; set; }
		public double Distance { get; set; }
		public double LapLength { get; set; }
		public double Offset { get; set; }
	}
}
