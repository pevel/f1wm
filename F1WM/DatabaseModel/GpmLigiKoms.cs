using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class GpmLigiKoms
    {
        public uint Komid { get; set; }
        public uint Ligaid { get; set; }
        public uint Zespolid { get; set; }
        public DateTime Czas { get; set; }
        public byte Status { get; set; }
        public string Autor { get; set; }
        public string Tresc { get; set; }
    }
}
