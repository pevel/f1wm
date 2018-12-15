using System;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
    public class CalendarRepository : RepositoryBase, ICalendarRepository
    {
        private readonly IMapper mapper;

        public async Task<CalendarRace> GetCalendar(int year)
        {
            var result = new CalendarRace();
            return result;
        }

        public CalendarRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
