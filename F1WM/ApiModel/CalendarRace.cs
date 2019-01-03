using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using F1WM.DatabaseModel;

namespace F1WM.ApiModel
{
    public class CalendarRace
    {
        public DateTime date { get; set; }
        public LapResultSummary PolePositionLapResult { get; set; }
        public RaceResultPosition WinnerRaceResult { get; set; }
        public FastestLapResultSummary FastestLapResult { get; set; }
        public string Name { get; set; }
        public string TranslatedName { get; set; }
        public double Distance { get; set; }
        public double LapLength { get; set; }
        public int Laps { get; set; }
        public TrackSummary Track { get; set; }
        public int Id { get; set; }
        public int TrackId { get; set; }
    }
}