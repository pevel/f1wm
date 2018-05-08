using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1quotes
    {
        public uint Id { get; set; }
        public uint Raceid { get; set; }
        public byte Qtype { get; set; }
        public byte Teampos { get; set; }
        public string Teamascid { get; set; }
        public uint Redid { get; set; }
        public string Poster { get; set; }
        public byte Hidden { get; set; }
        public string Q1name { get; set; }
        public string Q1nameadd { get; set; }
        public string Q1text { get; set; }
        public string Q2name { get; set; }
        public string Q2nameadd { get; set; }
        public string Q2text { get; set; }
        public string Q3name { get; set; }
        public string Q3nameadd { get; set; }
        public string Q3text { get; set; }
        public string Q4name { get; set; }
        public string Q4nameadd { get; set; }
        public string Q4text { get; set; }
        public string Teaminfo { get; set; }
        public DateTime Date { get; set; }
    }
}
