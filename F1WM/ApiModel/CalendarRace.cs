using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using F1WM.DatabaseModel;

namespace F1WM.ApiModel
{
    public class CalendarRace
    {
        [DisplayFormat(DataFormatString = "{yyyy/mm/dd:HH:MM:ss}")]
        public DateTime date { get; set; }
        public QualifyingResultPosition polePositionLapResult { get; set; }
        public RaceResultPosition winnerRaceResult { get; set; }
        public FastestLapResultSummary fastestLapResult { get; set; }
        public string name { get; set; }
        public string translatedName { get; set; }
        public double distance { get; set; }
        public double lapLength { get; set; }
        public int laps { get; set; }
        public TrackSummary track { get; set; }
        public int raceid { get; set; }
        public int trackid { get; set; }
    }
}