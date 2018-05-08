using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class StatLog
    {
        public uint LogId { get; set; }
        public DateTime LogDataiczas { get; set; }
        public string LogIp { get; set; }
        public string LogHost { get; set; }
        public string LogAgent { get; set; }
        public uint LogStronaid { get; set; }
    }
}
