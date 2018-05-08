using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1cars
    {
        public uint Carid { get; set; }
        public uint Carmakeid { get; set; }
        public string Car { get; set; }
        public uint? Launch1newsid { get; set; }
        public uint? Launch2newsid { get; set; }
        public string Litera { get; set; }
        public uint Albumid { get; set; }
    }
}
