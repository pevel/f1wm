using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class ConstructorStandingsPosition
	{
		public uint Id { get; set; }
		public uint SeasonId { get; set; }
		public uint CarMakeId { get; set; }
		public uint EngineMakeId { get; set; }
		public ushort Position { get; set; }
		public double Points { get; set; }
	}
}
