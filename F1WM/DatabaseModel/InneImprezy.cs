using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class InneImprezy
    {
        public uint Id { get; set; }
        public uint Seriaid { get; set; }
        public string Sezon { get; set; }
        public byte Nrwsez { get; set; }
        public string Nazwa { get; set; }
        public string Dzien { get; set; }
        public string Tor { get; set; }
        public string Kraj { get; set; }
        public ushort Okrazenia { get; set; }
        public uint Dlugtoru { get; set; }
        public byte Typ { get; set; }
        public uint Newsid { get; set; }
        public string Galeriaurl { get; set; }
        public string Godzina { get; set; }
        public byte Bezstats { get; set; }
        public uint Startgrupy { get; set; }
        public byte Typtoru { get; set; }
        public string Rokmies { get; set; }
    }
}
