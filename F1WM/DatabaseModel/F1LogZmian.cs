using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class F1LogZmian
	{
		public string Id { get; set; }
		public DateTime Data { get; set; }
		public uint UserId { get; set; }
		public uint NewsId { get; set; }
		public uint ArtId { get; set; }
		public uint CommId { get; set; }
		public string Autor { get; set; }
		public string Zmiany { get; set; }
		public uint TextId { get; set; }
	}
}