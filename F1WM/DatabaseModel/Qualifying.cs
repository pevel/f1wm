using System;

namespace F1WM.DatabaseModel
{
    public class Qualifying
    {
        public uint EntryId { get; set; }
        public uint RaceId { get; set; }
        public string PositionOrStatus { get; set; }
        public int? FinishPosition { get; set; }
        public string Status { get; set; }
        public byte Ord { get; set; }
        public string Information { get; set; }
        public byte Session1Position { get; set; }
        public byte Session1Laps { get; set; }
        public TimeSpan Session1Time { get; set; }
        public byte Session2Position { get; set; }
        public byte Session2Laps { get; set; }
        public TimeSpan Session2Time { get; set; }
        public byte Session3Position { get; set; }
        public byte Session3Laps { get; set; }
        public TimeSpan Session3Time { get; set; }
        public virtual Entry Entry { get; set; }
        public virtual Race Race { get; set; }
    }
}