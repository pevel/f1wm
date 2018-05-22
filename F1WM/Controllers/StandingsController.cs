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
		private IStandingsService service;
		private ILoggingService logger;

		[HttpGet("constructors")]
		[Produces("application/json", Type = typeof(ConstructorsStandings))]
		public async Task<IActionResult> GetConstructorsStandings([FromQuery(Name = "seasonId")] int? seasonId = null)
		{
			try
			{
				return Ok(await service.GetConstructorsStandings(seasonId));
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("drivers")]
		public Task<IActionResult> GetDriversStandings()
		{
			throw new NotImplementedException();
		}

		public StandingsController(IStandingsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}