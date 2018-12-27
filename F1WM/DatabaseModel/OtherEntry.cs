using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class OtherEntry
	{
		public uint Id { get; set; }
		public uint OtherSeriesId { get; set; }
		public string Season { get; set; }
		public string Number { get; set; }
		public uint OtherDriverId { get; set; }
		public string TeamName { get; set; }
		public string CarName { get; set; }
		public byte Independent { get; set; }
		public string Tyres { get; set; }
		public byte Inactive { get; set; }
		public byte Debut { get; set; }
		public string Class { get; set; }
		public byte Guest { get; set; }
		public virtual OtherDriver Driver { get; set; }
	}
}