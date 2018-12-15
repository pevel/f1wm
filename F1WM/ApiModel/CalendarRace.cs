using System;
using System.ComponentModel.DataAnnotations;
using F1WM.DatabaseModel;

namespace F1WM.ApiModel
{
    public class CalendarRace
    {
        [DisplayFormat(DataFormatString = "{yyyy/mm/dd:HH:MM:ss}")]
        public DateTime date { get; set; }
        public QualifyingResult polePositionLapResult { get; set; }
        public RaceResult winnerRaceResult { get; set; }
        public LapResultSummary fastestLapResult { get; set; }
        public string name { get; set; }
        public string translatedName { get; set; }
        public double lapLength { get; set; }
        public int laps { get; set; }
        public string track { get; set; }
        public int raceid { get; set; }
        public int trackid { get; set; }
    }
}