using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class RaceNews
	{
		public uint RaceId { get; set; }
		public uint? Training1NewsId { get; set; }
		public uint? Training2NewsId { get; set; }
		public uint? Training3NewsId { get; set; }
		public uint? TyresNewsId { get; set; }
		public uint? CommentsAfterQualifyingResultsNewsId { get; set; }
		public uint? QualifyingNewsId { get; set; }
		public uint? CommentsAfterRaceResultsNewsId { get; set; }
		public uint? FastestLapsNewsId { get; set; }
		public uint? PitStopsNewsId { get; set; }
		public uint? Id { get; set; }
		public uint? CommentsAfterQualifyingNewsId { get; set; }
		public uint? CommentsAfterRaceNewsId { get; set; }
		public uint? CommentsAfterTrainingNewsId { get; set; }
		public uint? PressConferenceNewsId { get; set; }
		public uint? GalleryNewsId { get; set; }
		public uint? ManeuversNewsId { get; set; }
	}
}
