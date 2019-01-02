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
        public async Task<Calendar> GetCalendar(int? year)
        {
            var news = await repository.GetCalendar(DateTime.Now.Year);
            return news;//.Select(n => n.ResolveTopicIcon());
        }

        public CalendarService(ICalendarRepository repository)
        {
            this.repository = repository;
        }
    }
}