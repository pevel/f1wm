using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class StatSesje
	{
		public string SesjaId { get; set; }
		public string SesjaIp { get; set; }
		public uint SesjaAgentcrc { get; set; }
		public int SesjaStart { get; set; }
		public int SesjaCzas { get; set; }
		public uint SesjaStronaid { get; set; }
	}
}