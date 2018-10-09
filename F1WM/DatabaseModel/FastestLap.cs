using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class FastestLap
    {
        public uint EntryId { get; set; }
        public uint RaceId { get; set; }
        public string Frlpos { get; set; }
        public byte Lap { get; set; }
        public byte Ord { get; set; }
        public TimeSpan Time { get; set; }
    }
}
