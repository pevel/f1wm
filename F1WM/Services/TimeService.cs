using System;

namespace F1WM.Services
{
	public class TimeService : ITimeService
	{
		public DateTime Now => System.DateTime.Now;
	}
}