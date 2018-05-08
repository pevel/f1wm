using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1othersessions
    {
        public uint Id { get; set; }
        public uint Raceid { get; set; }
        public string Session { get; set; }
        public uint Entryid { get; set; }
        public byte Sespos { get; set; }
        public double Time { get; set; }
        public byte Laps { get; set; }
    }
}
