using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.ApiModel
{
	public class TrackSummary : TrackBase
	{
		public string City { get; set; }
		public string Name { get; set; }
		public Country Country { get; set; }
		public byte StatusId { get; set; }
	}
}
