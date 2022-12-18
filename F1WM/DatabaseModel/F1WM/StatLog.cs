using System;

namespace F1WM.DatabaseModel
{
	public class StatLog
	{
		public int LogId { get; set; }
		public DateTime LogDataiczas { get; set; }
		public string LogIp { get; set; }
		public string LogHost { get; set; }
		public string LogAgent { get; set; }
		public int LogStronaid { get; set; }
	}
}