using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using static F1WM.Utilities.Constants;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class CalendarController : ControllerBase
	{
		private readonly ICalendarService service;
		private readonly ICachingService cachingService;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Calendar>> GetCalendar([FromQuery(Name = "year")] int? year)
		{
			var cacheKey = $"{CacheKeys.Calendar}_{year}";
			var responseData = cachingService.TryGetCacheValue<Calendar>(cacheKey);
			if (responseData is null)
			{
				responseData = await service.GetCalendar(year);
				cachingService.Set(cacheKey, responseData, TimeSpan.FromDays(1));
			}
			return this.NotFoundResultIfNull(responseData);
		}

		public CalendarController(ICalendarService service, ICachingService cachingService)
		{
			this.service = service;
			this.cachingService = cachingService;
		}
	}
}
