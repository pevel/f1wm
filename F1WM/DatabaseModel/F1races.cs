using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1races
    {
        public uint Raceid { get; set; }
        public uint Seasonid { get; set; }
        public byte Numinseason { get; set; }
        public string Country { get; set; }
        public uint Trackid { get; set; }
        public byte Weather { get; set; }
        public byte Laps { get; set; }
        public double Offset { get; set; }
        public string Name { get; set; }
        public byte Trackver { get; set; }
        public byte Gridtype { get; set; }
        public byte Qualtype { get; set; }
        public string Yearmonth { get; set; }
    }
}
