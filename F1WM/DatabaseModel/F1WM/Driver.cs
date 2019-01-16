using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Driver
	{
		public uint Id { get; set; }
		public string Ascid { get; set; }
		public string Surname { get; set; }
		public string FirstName { get; set; }
		public string Initial { get; set; }
		public string NationalityKey { get; set; }
		public string Birthplc { get; set; }
		public string Resides { get; set; }
		public string Status { get; set; }
		public string Kids { get; set; }
		public string Height { get; set; }
		public string Weight { get; set; }
		public string Titles { get; set; }
		public string Testdriver { get; set; }
		public uint? Artid { get; set; }
		public ushort Group { get; set; }
		public string Teamascid { get; set; }
		public string Deathplc { get; set; }
		public ushort Birthmd { get; set; }
		public ushort Deathmd { get; set; }
		public string Litera { get; set; }
		public ushort Debiut { get; set; }
		public string Career { get; set; }
		public virtual IEnumerable<DriverStandingsPosition> Positions { get; set; }
		public virtual Country Nationality { get; set; }
	}
}