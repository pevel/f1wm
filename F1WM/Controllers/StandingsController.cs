using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using static F1WM.Utilities.Constants;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class StandingsController : ControllerBase
	{
		private const int defaultConstructorsStandingsCount = 10;
		private const int defaultDriversStandingsCount = 10;

		private readonly IStandingsService service;
		private readonly ICachingService cachingService;

		[HttpGet("constructors")]
		public async Task<ActionResult<ConstructorsStandings>> GetConstructorsStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultConstructorsStandingsCount)
		{
			var cacheKey = $"{CacheKeys.ConstructorsStanding}_{seasonId}_{count}";
			var responseData = cachingService.TryGetCacheValue<ConstructorsStandings>(cacheKey);
			if (responseData is null)
			{
				responseData = await service.GetConstructorsStandings(count, seasonId);
				cachingService.Set(cacheKey, responseData, TimeSpan.FromDays(1));
			}
			return Ok(responseData);
		}

		[HttpGet("drivers")]
		public async Task<ActionResult<DriversStandings>> GetDriversStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultDriversStandingsCount)
		{
			var cacheKey = $"{CacheKeys.DriversStanding}_{seasonId}_{count}";
			var responseData = cachingService.TryGetCacheValue<DriversStandings>(cacheKey);
			if (responseData is null)
			{
				responseData = await service.GetDriversStandings(count, seasonId);
				cachingService.Set(cacheKey, responseData, TimeSpan.FromDays(1));
			}
			return Ok(responseData);
		}

		public StandingsController(IStandingsService service, ICachingService cachingService)
		{
			this.service = service;
			this.cachingService = cachingService;
		}
	}
}
