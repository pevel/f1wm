using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class Grid
    {
        public uint EntryId { get; set; }
        public uint RaceId { get; set; }
        public string StartingPosition { get; set; }
        public byte Ord { get; set; }
        public TimeSpan Time { get; set; }
        public virtual Entry Entry { get; set; }
        public virtual Race Race { get; set; }
    }
}
