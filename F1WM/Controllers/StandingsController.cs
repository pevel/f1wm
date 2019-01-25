using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class StandingsController : ControllerBase
	{
		private const int defaultConstructorsStandingsCount = 10;
		private const int defaultDriversStandingsCount = 10;

		private readonly IStandingsService service;
		private readonly ILoggingService logger;

		[HttpGet("constructors")]
		[Produces("application/json", Type = typeof(ConstructorsStandings))]
		[ProducesResponseType(200)]
		public async Task<IActionResult> GetConstructorsStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultConstructorsStandingsCount)
		{
			try
			{
				var standings = await service.GetConstructorsStandings(count, seasonId);
				return Ok(standings);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("drivers")]
		[Produces("application/json", Type = typeof(DriversStandings))]
		[ProducesResponseType(200)]
		public async Task<IActionResult> GetDriversStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultDriversStandingsCount)
		{
			try
			{
				var standings = await service.GetDriversStandings(count, seasonId);
				return Ok(standings);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public StandingsController(IStandingsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
