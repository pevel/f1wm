using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class InneRezultatyBk
    {
        public uint Id { get; set; }
        public uint Imprezaid { get; set; }
        public ushort Okrazenia { get; set; }
        public double Czas { get; set; }
        public byte Pozycja { get; set; }
        public string Status { get; set; }
        public uint Zgloszenieid { get; set; }
        public ushort Dodpktza { get; set; }
        public byte Pozklasa { get; set; }
    }
}
