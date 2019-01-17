using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Event
	{
		public uint Id { get; set; }
		public uint OtherSeriesId { get; set; }
		public string Season { get; set; }
		public byte Nrwsez { get; set; }
		public string Name { get; set; }
		public string Dzien { get; set; }
		public string TrackName { get; set; }
		public string NationalityKey { get; set; }
		public ushort Laps { get; set; }
		public uint TrackLength { get; set; }
		public byte Type { get; set; }
		public uint NewsId { get; set; }
		public string Galeriaurl { get; set; }
		public string Godzina { get; set; }
		public byte Bezstats { get; set; }
		public uint Startgrupy { get; set; }
		public byte Typtoru { get; set; }
		public string Rokmies { get; set; }
		public virtual OtherSeries Series { get; set; }
		public virtual Country Nationality { get; set; }
		public virtual IEnumerable<OtherResult> Results { get; set; }
	}
}
