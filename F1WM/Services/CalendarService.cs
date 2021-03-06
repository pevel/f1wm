using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class CalendarService : ICalendarService
	{
		private readonly ICalendarRepository repository;
		private readonly ITimeService timeService;

		public Task<Calendar> GetCalendar(int? year)
		{
			return repository.GetCalendar(year.HasValue ? year.Value : timeService.Now.Year);
		}

		public CalendarService(ICalendarRepository repository, ITimeService timeService)
		{
			this.repository = repository;
			this.timeService = timeService;
		}
	}
}
