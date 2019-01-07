using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Race
	{
		public uint Id { get; set; }
		public uint Seasonid { get; set; }
		public byte Numinseason { get; set; }
		public string CountryKey { get; set; }
		public uint TrackId { get; set; }
		public bool Weather { get; set; }
		public byte Laps { get; set; }
		public double Distance { get; set; }
		public double Offset { get; set; }
		public string Name { get; set; }
		public byte Trackver { get; set; }
		public byte Gridtype { get; set; }
		public byte Qualtype { get; set; }
		public string Yearmonth { get; set; }
		public DateTime Date { get; set; }
		public virtual Track Track { get; set; }
		public virtual Country Country { get; set; }
		public virtual IEnumerable<Grid> Grids { get; set; }
		public virtual IEnumerable<Result> Results { get; set; }
		public virtual FastestLap FastestLap { get; set; }
		public virtual RaceNews RaceNews { get; set; }
		public virtual IEnumerable<Qualifying> Qualifying { get; set; }
	}
}