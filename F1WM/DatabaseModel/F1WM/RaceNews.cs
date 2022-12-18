namespace F1WM.DatabaseModel
{
	public class RaceNews
	{
		public int RaceId { get; set; }
		public ushort Year { get; set; }
		public byte Number { get; set; }
		public int? Pt { get; set; }
		public int? T12 { get; set; }
		public int? Training1NewsId { get; set; }
		public int? Training2NewsId { get; set; }
		public int? T34 { get; set; }
		public int? Training3NewsId { get; set; }
		public int? T4 { get; set; }
		public int? K1 { get; set; }
		public int? K2 { get; set; }
		public int? TyresNewsId { get; set; }
		public int? CommentsAfterQualifyingResultsNewsId { get; set; }
		public int? QualifyingNewsId { get; set; }
		public int? Wu { get; set; }
		public int? CommentsAfterRaceResultsNewsId { get; set; }
		public int? FastestLapsNewsId { get; set; }
		public int? PitStopsNewsId { get; set; }
		public int? Pw { get; set; }
		public int? Id { get; set; }
		public int? CommentsAfterQualifyingNewsId { get; set; }
		public int? CommentsAfterRaceNewsId { get; set; }
		public int? CommentsAfterTrainingNewsId { get; set; }
		public int? PressConferenceNewsId { get; set; }
		public int? Wbk { get; set; }
		public int? Gp { get; set; }
		public int? K1p { get; set; }
		public int? GalleryNewsId { get; set; }
		public int? ManeuversNewsId { get; set; }
		public virtual Race Race { get; set; }
	}
}
