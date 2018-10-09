using System;
using F1WM.DatabaseModel;

public static class EntryExtensions
{
    public static TimeSpan GetLapTime(this Entry entry)
    {
        return entry.Grid != null ? entry.Grid.Time : entry.FastestLap.Time;
    }
}