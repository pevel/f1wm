using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class GpmAdmkonfig
    {
        public byte Id { get; set; }
        public ushort Rok { get; set; }
        public byte Koniec1fazy { get; set; }
        public uint Startmoney { get; set; }
        public uint Cenapunktu { get; set; }
        public double Zwrotmnoz { get; set; }
        public double Kier3cenamnoz { get; set; }
        public double Kier3zwrotmnoz { get; set; }
        public double Kier3cenamnozprzed { get; set; }
        public byte Wymusblokade { get; set; }
        public string Komunikaty { get; set; }
        public string Sponsorzy { get; set; }
        public string Typowanie { get; set; }
        public byte Krokinicjalizacji { get; set; }
        public string Powodblokady { get; set; }
        public string Przelcennik1 { get; set; }
        public string Przelcennik2 { get; set; }
        public byte Typpktpomylka { get; set; }
        public double Zwrotmnoz1faza { get; set; }
    }
}
