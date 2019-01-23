using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.ApiModel
{
	public class DriversList
	{
		public IEnumerable<DriverSummary> Drivers { get; set; }
	}
}
