using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class DriverStandingsPosition
	{
		public uint Id { get; set; }
		public uint SeasonId { get; set; }
		public uint DriverId { get; set; }
		public ushort Position { get; set; }
		public double Points { get; set; }
		public virtual Driver Driver { get; set; }
		public virtual Season Season { get; set; }
	}
}
