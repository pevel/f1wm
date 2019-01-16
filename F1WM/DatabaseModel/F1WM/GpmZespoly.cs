using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class GpmZespoly
	{
		public uint Zespolid { get; set; }
		public string Login { get; set; }
		public string Haslo { get; set; }
		public string Email { get; set; }
		public string Nazwa { get; set; }
		public uint Gotowka { get; set; }
		public byte Pokazujemail { get; set; }
		public string Nazwisko { get; set; }
		public string Siedziba { get; set; }
		public byte Plec { get; set; }
		public uint? Gg { get; set; }
		public string Ulubkier { get; set; }
		public string Ulubzesp { get; set; }
		public string Ulubtor { get; set; }
		public string Typavatara { get; set; }
		public int Ostwizyta { get; set; }
		public string Adresip { get; set; }
		public uint Aktywacja { get; set; }
		public int Agentcrc { get; set; }
		public uint Ligaid { get; set; }
		public uint Ligaidzapr { get; set; }
		public byte Pokazujsklad { get; set; }
		public string Nowehaslo { get; set; }
		public uint Wartosc { get; set; }
	}
}