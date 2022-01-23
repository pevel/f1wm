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
	public class RacesController : ControllerBase
	{
		private readonly IRacesService racesService;
		private readonly IStandingsService standingsService;
		private readonly ICachingService cachingService;

		[HttpGet("next")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<NextRaceSummary>> GetNextRace([FromQuery] DateTime? after)
		{
			var cacheKey = $"{CacheKeys.NextRace}_{after}";
			var responseData = cachingService.TryGetCacheValue<NextRaceSummary>(cacheKey);
			if (responseData is null)
			{
				responseData = await racesService.GetNextRace(after);
				cachingService.Set(cacheKey, responseData, TimeSpan.FromDays(1));
			}
			return this.NotFoundResultIfNull(responseData);
		}

		[HttpGet("last")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<LastRaceSummary>> GetLastRace([FromQuery] DateTime? before)
		{
			var cacheKey = $"{CacheKeys.LastRace}_{before}";
			var responseData = cachingService.TryGetCacheValue<LastRaceSummary>(cacheKey);
			if (responseData is null)
			{
				responseData = await racesService.GetLastRace(before);
				cachingService.Set(cacheKey, responseData, TimeSpan.FromDays(1));
			}
			return this.NotFoundResultIfNull(responseData);
		}

		[HttpGet("{raceId}/news")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceNews>> GetRaceNews(int raceId)
		{
			var raceNews = await racesService.GetRaceNews(raceId);
			return this.NotFoundResultIfNull(raceNews);
		}

		[HttpGet("{raceId}/fastest-laps")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceFastestLaps>> GetRaceFastestLaps(int raceId)
		{
			var fastestLaps = await racesService.GetRaceFastestLaps(raceId);
			return this.NotFoundResultIfNull(fastestLaps);
		}

		[HttpGet("{raceId}/standings/constructors")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<ConstructorsStandingsAfterRace>> GetConstructorsStandingsAfterRace(int raceId)
		{
			var standings = await standingsService.GetConstructorsStandingsAfterRace(raceId);
			return this.NotFoundResultIfNull(standings);
		}


		[HttpGet("{raceId}/standings/drivers")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<DriversStandingsAfterRace>> GetDriversStandingsAfterRace(int raceId)
		{
			var standings = await standingsService.GetDriversStandingsAfterRace(raceId);
			return this.NotFoundResultIfNull(standings);
		}

		public RacesController(IRacesService racesService, IStandingsService standingsService, ICachingService cachingService)
		{
			this.racesService = racesService;
			this.standingsService = standingsService;
			this.cachingService = cachingService;
		}
	}
}
