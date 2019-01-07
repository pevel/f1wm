using System.Collections;
using System.Collections.Generic;

namespace F1WM.ApiModel
{
	public class Calendar
	{
		public int SeasonId { get; set; }
		public IEnumerable<CalendarRace> Races { get; set; }
	}
}