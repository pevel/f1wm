using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class ConstructorPoints
	{
		public uint Id { get; set; }
		public uint RaceId { get; set; }
		public uint SeasonId { get; set; }
		public uint ConstructorId { get; set; }
		public uint EngineMakeId { get; set; }
		public float? Points { get; set; }
		public float? NotCountedTowardsChampionshipPoints { get; set; }
		public virtual Race Race { get; set; }
		public virtual Season Season { get; set; }
		public virtual Constructor Constructor { get; set; }
		public virtual EngineMake EngineMake { get; set; }
	}
}
