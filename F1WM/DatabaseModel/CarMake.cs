﻿using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class CarMake
	{
		public uint Id { get; set; }
		public string Ascid { get; set; }
		public string Name { get; set; }
		public string Nat { get; set; }
		public byte Status { get; set; }
		public string Litera { get; set; }
	}
}
