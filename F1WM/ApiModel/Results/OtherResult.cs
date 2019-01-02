using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class OtherResult
	{
		public int EventId { get; set; }
		public SeriesSummary Series { get; set; }
		public IEnumerable<OtherResultPosition> Results { get; set; }
		public FastestLapResultSummary FastestLapResult { get; set; }
		public LapResultSummary PolePositionLapResult { get; set; }
	}
}