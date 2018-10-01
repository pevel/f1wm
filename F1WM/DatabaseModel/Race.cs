using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Race
	{
		public uint Id { get; set; }
		public uint Seasonid { get; set; }
		public byte Numinseason { get; set; }
		public string Country { get; set; }
		public uint TrackId { get; set; }
		public bool Weather { get; set; }
		public byte Laps { get; set; }
		public double Offset { get; set; }
		public string Name { get; set; }
		public bool Trackver { get; set; }
		public byte Gridtype { get; set; }
		public byte Qualtype { get; set; }
		public string Yearmonth { get; set; }
		public DateTime Date { get; set; }
		public virtual Track Track { get; set; }
	}
}
