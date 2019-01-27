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
		public string FirstTeamPrincipal { get; set; }
		public string TeamPrincipal { get; set; }
		public string TechnicalDirector { get; set; }
		public string FounderPicture { get; set; }
		public string FirstTeamPrincipalPicture { get; set; }
		public string TeamPrincipalPicture { get; set; }
		public string TechnicalDirectorPicture { get; set; }
		public uint? NewsTopicId { get; set; }
		public ushort Status { get; set; }
		public string Secondfactory { get; set; }
		public string EngineeringDirector { get; set; }
		public string EngineeringDirectorPicture { get; set; }
		public string Basedonteam { get; set; }
		public uint? Artid { get; set; }
		public string OtherDirector { get; set; }
		public string OtherDirectorPicture { get; set; }
		public string OtherDirectorOccupancy { get; set; }
		public uint? Carmakeid { get; set; }
		public string Letter { get; set; }
		public string Teamshort { get; set; }
		public virtual Country Country { get; set; }
		public virtual Link Link { get; set; }
	}
}
