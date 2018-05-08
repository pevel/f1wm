using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1Linki
    {
        public uint LId { get; set; }
        public string LUrl { get; set; }
        public uint LCatgrp { get; set; }
        public string LCatstr { get; set; }
        public string LNazwa { get; set; }
        public string LOpis { get; set; }
        public string LJezyki { get; set; }
        public DateTime LData { get; set; }
        public byte LOcena { get; set; }
        public uint LOdslony { get; set; }
        public byte LStatus { get; set; }
        public string LBanurl { get; set; }
        public byte LRotator { get; set; }
    }
}
