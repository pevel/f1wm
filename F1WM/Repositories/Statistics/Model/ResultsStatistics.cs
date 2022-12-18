namespace F1WM.Repositories.Statistics.Model
{
	public class ResultsStatistics
	{
		public int SeasonId { get; set; }
		public int Wins { get; set; }
		public int Podiums { get; set; }
		public int NotClassified { get; set; }
		public int NotFinished { get; set; }
	}
}
