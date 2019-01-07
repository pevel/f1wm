using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class OtherDriver
	{
		public uint Id { get; set; }
		public string FirstName { get; set; }
		public string Initial { get; set; }
		public string Surname { get; set; }
		public string NationalityKey { get; set; }
		public string F1ascid { get; set; }
		public byte Gender { get; set; }
		public string Litera { get; set; }
		public virtual Country Nationality { get; set; }
	}
}