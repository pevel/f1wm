using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class TrackDetails : Track
	{
		public string Address { get; set; }
		public string Website { get; set; }
		public ushort? LongestStraight { get; set; }
		public string Width { get; set; }
		public TrackRaceSummary LastRace { get; set; }
		public TimeSpan RaceStartLocal { get; set; }
		public TimeSpan RaceStartPoland { get; set; }
		public string Coordinates { get; set; }
		public string Image { get; set; }
	}
}
