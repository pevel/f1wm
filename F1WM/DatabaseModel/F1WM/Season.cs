using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Season
	{
		public uint Id { get; set; }
		public ushort Year { get; set; }
		public byte Races { get; set; }
		public byte Lastrace { get; set; }
		public string Reviewnews { get; set; }
		public string Reviewarts { get; set; }
		public string PointsSystem { get; set; }
		public string EngineRules { get; set; }
		public string CarWeight { get; set; }
		public string QualifyingRules { get; set; }
		public uint Newstyres { get; set; }
		public IEnumerable<DriverStandingsPosition> DriverStandings { get; set; }
		public IEnumerable<ConstructorStandingsPosition> ConstructorStandings { get; set; }
	}
}
