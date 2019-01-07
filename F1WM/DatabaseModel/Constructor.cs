using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Constructor
	{
		public uint Id { get; set; }
		public string Ascid { get; set; }
		public string Name { get; set; }
		public string NationalityKey { get; set; }
		public byte Status { get; set; }
		public string Letter { get; set; }
		public virtual IEnumerable<ConstructorStandingsPosition> Positions { get; set; }
		public virtual Country Nationality { get; set; }
	}
}