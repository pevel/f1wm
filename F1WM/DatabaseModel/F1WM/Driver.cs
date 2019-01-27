using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Driver
	{
		public uint Id { get; set; }
		public string Key { get; set; }
		public string Surname { get; set; }
		public string FirstName { get; set; }
		public string Initial { get; set; }
		public string NationalityKey { get; set; }
		public string BirthPlace { get; set; }
		public string Residence { get; set; }
		public string MaritalStatus { get; set; }
		public string Kids { get; set; }
		public string Height { get; set; }
		public string Weight { get; set; }
		public string ChampionAtSeries { get; set; }
		public string Testdriver { get; set; }
		public uint? Artid { get; set; }
		public DriverGroup Group { get; set; }
		public string TeamKey { get; set; }
		public string DeathPlace { get; set; }
		public ushort Birthmd { get; set; }
		public ushort Deathmd { get; set; }
		public string Litera { get; set; }
		public ushort DebutYear { get; set; }
		public string CareerText { get; set; }
		public DateTime Birthday { get; set; }
		public virtual IEnumerable<DriverStandingsPosition> StandingsPositions { get; set; }
		public virtual Country Nationality { get; set; }
		public virtual IEnumerable<Entry> Entries { get; set; }
		public virtual Link Link { get; set; }
		public virtual Team Team { get; set; }
	}
}
