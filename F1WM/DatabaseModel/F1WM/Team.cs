using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class Team
	{
		public uint Id { get; set; }
		public string Key { get; set; }
		public string Name { get; set; }
		public string NationalityKey { get; set; }
		public string Headquarters { get; set; }
		public string Founder { get; set; }
		public string Firstboss { get; set; }
		public string TeamPrincipal { get; set; }
		public string TechnicalDirector { get; set; }
		public string Founderpic { get; set; }
		public string Firstbosspic { get; set; }
		public string Curbosspic { get; set; }
		public string Curtechdirpic { get; set; }
		public uint? NewsTopicId { get; set; }
		public ushort Status { get; set; }
		public string Secondfactory { get; set; }
		public string Curengboss { get; set; }
		public string Curengbosspic { get; set; }
		public string Basedonteam { get; set; }
		public uint? Artid { get; set; }
		public string Otherboss { get; set; }
		public string Otherbosspic { get; set; }
		public string Otherbossocc { get; set; }
		public uint? Carmakeid { get; set; }
		public string Letter { get; set; }
		public string Teamshort { get; set; }
		public virtual Country Country { get; set; }
		public virtual Link Link { get; set; }
	}
}
