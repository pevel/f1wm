using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class InneListystart
    {
        public uint Id { get; set; }
        public uint Seriaid { get; set; }
        public string Sezon { get; set; }
        public string Nr { get; set; }
        public uint Kierowcaid { get; set; }
        public string Zespol { get; set; }
        public string Samochod { get; set; }
        public string Zespolwwyniku { get; set; }
        public byte Niezalezny { get; set; }
        public string Opony { get; set; }
        public byte Nieaktywny { get; set; }
        public byte Debiutant { get; set; }
        public string Klasa { get; set; }
        public byte Gosc { get; set; }
    }
}
