using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1fastestlaps
    {
        public uint Entryid { get; set; }
        public uint Raceid { get; set; }
        public string Frlpos { get; set; }
        public byte Lap { get; set; }
        public byte Ord { get; set; }
    }
}
