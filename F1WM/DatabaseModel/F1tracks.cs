using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1tracks
    {
        public uint Trackid { get; set; }
        public string Ascid { get; set; }
        public string Track { get; set; }
        public string Country { get; set; }
        public string Fulltrackname { get; set; }
        public string City { get; set; }
        public ushort? Longeststraight { get; set; }
        public string Width { get; set; }
        public string Pitwindows1 { get; set; }
        public string Pitwindows2 { get; set; }
        public string Pitwindows3 { get; set; }
        public string Startlocal { get; set; }
        public string Startpoland { get; set; }
        public string Orgaddress { get; set; }
        public string Orgtel { get; set; }
        public string Orgfax { get; set; }
        public uint? Artid { get; set; }
        public string Weatherurl { get; set; }
        public string Zipcode { get; set; }
        public string Satmapcoords { get; set; }
        public byte? Satmapzoom { get; set; }
        public byte Status { get; set; }
        public byte Fiatrackmap { get; set; }
        public ushort? Length { get; set; }
        public uint? Newstopicid { get; set; }
        public string LapDriver { get; set; }
        public string LapDescr { get; set; }
    }
}
