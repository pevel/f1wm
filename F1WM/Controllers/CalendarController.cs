using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class CalendarController : ControllerBase
	{
		private readonly ICalendarService service;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Calendar>> GetCalendar(
			[FromQuery(Name = "year")] int? year)
		{
			var calendar = await service.GetCalendar(year);
			return this.NotFoundResultIfNull(calendar);
		}

		public CalendarController(ICalendarService service)
		{
			this.service = service;
		}
	}
}
