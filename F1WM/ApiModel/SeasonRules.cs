using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.ApiModel
{
    public class SeasonRules
    {
        public int Id { get; set; }
        public string PointsSystem { get; set; }
        public string EngineRules { get; set; }
        public string CarWeight { get; set; }
        public string QualRules { get; set; }
    }
}
