using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1teams
	{
		public uint Teamid { get; set; }
		public string Ascid { get; set; }
		public string Team { get; set; }
		public string Nat { get; set; }
		public string Base { get; set; }
		public string Founder { get; set; }
		public string Firstboss { get; set; }
		public string Curboss { get; set; }
		public string Curtechdir { get; set; }
		public string Founderpic { get; set; }
		public string Firstbosspic { get; set; }
		public string Curbosspic { get; set; }
		public string Curtechdirpic { get; set; }
		public uint? Newstopicid { get; set; }
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
		public string Litera { get; set; }
		public string Teamshort { get; set; }
	}
}