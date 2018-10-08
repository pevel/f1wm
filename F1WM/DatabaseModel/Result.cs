using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class Result
    {
        public uint EntryId { get; set; }
        public uint RaceId { get; set; }
        public string FinishPosition { get; set; }
        public byte Laps { get; set; }
        public string Info { get; set; }
        public byte Ord { get; set; }
        public byte? Pits { get; set; }
        public TimeSpan Time { get; set; }
        public virtual Entry Entry { get; set; }
        public virtual Race Race { get; set; }
    }
}
