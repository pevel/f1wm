using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1ArtsCats
    {
        public uint Catid { get; set; }
        public string Name { get; set; }
        public uint Arts { get; set; }
        public uint Lastartid { get; set; }
        public byte Ord { get; set; }
    }
}
