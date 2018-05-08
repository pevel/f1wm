using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1quals
    {
        public uint Entryid { get; set; }
        public uint Raceid { get; set; }
        public string Qualpos { get; set; }
        public byte Ord { get; set; }
        public string Info { get; set; }
        public byte Q1pos { get; set; }
        public byte Q1laps { get; set; }
        public byte Q2pos { get; set; }
        public byte Q2laps { get; set; }
        public byte Q3pos { get; set; }
        public byte Q3laps { get; set; }
    }
}
