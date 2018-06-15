using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class CarMake
	{
		public uint Id { get; set; }
		public string Ascid { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public bool Status { get; set; }
		public string Letter { get; set; }
		public IEnumerable<ConstructorStandingsPosition> Positions { get; set; }
	}
}
