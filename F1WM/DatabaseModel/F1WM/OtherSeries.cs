using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class OtherSeries
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public uint NewsCategoryId { get; set; }
		public byte Listastartwgnr { get; set; }
		public byte Klaskieroficjalna { get; set; }
		public byte Klaszespoficjalna { get; set; }
		public byte Innepktdlazesp { get; set; }
		public string Domyslnysezon { get; set; }
		public string Www { get; set; }
		public byte Status { get; set; }
		public byte Tylkonewsy { get; set; }
		public string Skrotnazwy { get; set; }
		public string Punkty { get; set; }
		public string Punkty2 { get; set; }
		public byte Dzielonejazdy { get; set; }
		public byte Klasy { get; set; }
		public virtual IEnumerable<Event> Events { get; set; }
	}
}
