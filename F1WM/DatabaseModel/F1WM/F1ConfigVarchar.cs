using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1ConfigVarchar
	{
		public uint Id { get; set; }
		public byte Section { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string Description { get; set; }
		public byte Type { get; set; }
	}
}