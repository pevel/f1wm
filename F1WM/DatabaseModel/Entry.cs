using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class Entry
    {
        public uint Entryid { get; set; }
        public uint Raceid { get; set; }
        public byte Number { get; set; }
        public uint Driverid { get; set; }
        public uint Teamid { get; set; }
        public uint Teamnameid { get; set; }
        public uint Carid { get; set; }
        public uint Carmakeid { get; set; }
        public uint Engineid { get; set; }
        public uint Enginemakeid { get; set; }
        public uint Tyresid { get; set; }
        public bool Thirddriver { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Grid Grid { get; set; }
        public virtual Result Result { get; set; }
    }
}
