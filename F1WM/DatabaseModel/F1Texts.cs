using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
    public class F1Texts
    {
        public uint Id { get; set; }
        public string Tytul { get; set; }
        public string Grupa { get; set; }
        public DateTime Zmieniony { get; set; }
        public string Tresc { get; set; }
        public byte Uprawnienia { get; set; }
    }
}
