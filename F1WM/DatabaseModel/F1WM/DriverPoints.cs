using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class DriverPoints
	{
		public uint Id { get; set; }
		public uint RaceId { get; set; }
		public uint SeasonId { get; set; }
		public uint DriverId { get; set; }
		public float? Points { get; set; }
		public float? NotCountedTowardsChampionshipPoints { get; set; }
		public virtual Driver Driver { get; set; }
		public virtual Season Season { get; set; }
		public virtual Race Race { get; set; }
		public virtual Entry Entry { get; set; }
	}
}
