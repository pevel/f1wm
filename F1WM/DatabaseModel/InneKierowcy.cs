using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class InneKierowcy
    {
        public uint Id { get; set; }
        public string Imie { get; set; }
        public string Inicjal { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public string F1ascid { get; set; }
        public byte Plec { get; set; }
        public string Litera { get; set; }
    }
}
