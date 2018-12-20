using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class Entry
    {
        public uint Id { get; set; }
        public uint RaceId { get; set; }
        public byte Number { get; set; }
        public uint DriverId { get; set; }
        public uint TeamId { get; set; }
        public uint TeamNameId { get; set; }
        public uint CarId { get; set; }
        public uint CarMakeId { get; set; }
        public uint EngineId { get; set; }
        public uint EngineMakeId { get; set; }
        public uint TyresId { get; set; }
        public bool ThirdDriver { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Grid Grid { get; set; }
        public virtual Result Result { get; set; }
        public virtual Race Race { get; set; }
        public virtual FastestLap FastestLap { get; set; }
        public virtual Car Car { get; set; }
        public virtual Tyres Tyres { get; set; }
        public virtual Qualifying Qualifying { get; set; }
    }
}