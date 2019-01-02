using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService service;
        private readonly ILoggingService logger;

        [HttpGet]
        public async Task<Calendar> GetCalendar([FromQuery(Name = "year")] int year)
        {
            try
            {
                return await service.GetCalendar(year);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }
        
        public CalendarController(ICalendarService service, ILoggingService logger)
        {
            this.service = service;
            this.logger = logger;
        }
    }
}