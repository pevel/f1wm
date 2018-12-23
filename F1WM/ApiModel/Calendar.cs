using System.Collections;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
    public class Calendar
    {
        public int seasonid { get; set; }
        public IEnumerable<CalendarRace> Races { get; set; }
    }
}