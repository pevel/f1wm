using System;

namespace F1WM.ApiModel
{
	public class EntryDriverSummary : DriverSummary
	{
		public int DebutYear { get; set; }
		public DateTime Birthday { get; set; }
	}
}
