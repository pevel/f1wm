using System;

namespace F1WM.ApiModel
{
	public class EntryDriverSummary : DriverSummary
	{
		public ushort DebutYear { get; set; }
		public DateTime Birthday { get; set; }
		public string Picture { get; set; }
	}
}
