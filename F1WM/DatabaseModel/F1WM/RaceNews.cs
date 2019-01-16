using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class RaceNews
	{
		public uint RaceId { get; set; }
		public ushort Year { get; set; }
		public byte Number { get; set; }
		public uint? Pt { get; set; }
		public uint? T12 { get; set; }
		public uint? Training1NewsId { get; set; }
		public uint? Training2NewsId { get; set; }
		public uint? T34 { get; set; }
		public uint? Training3NewsId { get; set; }
		public uint? T4 { get; set; }
		public uint? K1 { get; set; }
		public uint? K2 { get; set; }
		public uint? TyresNewsId { get; set; }
		public uint? CommentsAfterQualifyingResultsNewsId { get; set; }
		public uint? QualifyingNewsId { get; set; }
		public uint? Wu { get; set; }
		public uint? CommentsAfterRaceResultsNewsId { get; set; }
		public uint? FastestLapsNewsId { get; set; }
		public uint? PitStopsNewsId { get; set; }
		public uint? Pw { get; set; }
		public uint? Id { get; set; }
		public uint? CommentsAfterQualifyingNewsId { get; set; }
		public uint? CommentsAfterRaceNewsId { get; set; }
		public uint? CommentsAfterTrainingNewsId { get; set; }
		public uint? PressConferenceNewsId { get; set; }
		public uint? Wbk { get; set; }
		public uint? Gp { get; set; }
		public uint? K1p { get; set; }
		public uint? GalleryNewsId { get; set; }
		public uint? ManeuversNewsId { get; set; }
	}
}