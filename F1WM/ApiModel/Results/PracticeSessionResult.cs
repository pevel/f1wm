using System;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class PracticeSessionResult
	{
		public int RaceId { get; set; }
		public int Session { get; set; }
		public IEnumerable<PracticeSessionResultPosition> Results { get; set; }
	}
}