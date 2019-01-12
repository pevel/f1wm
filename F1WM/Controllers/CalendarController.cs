using System;
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
		[Produces("application/json", Type = typeof(Calendar))]
		public async Task<IActionResult> GetCalendar([FromQuery(Name = "year")] int? year)
		{
			try
			{
				var calendar = await service.GetCalendar(year);
				if (calendar != null)
				{
					return Ok(calendar);
				}
				else
				{
					return NotFound();
				}
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