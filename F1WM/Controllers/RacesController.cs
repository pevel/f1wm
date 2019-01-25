using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class RacesController : ControllerBase
	{
		private readonly IRacesService service;
		private readonly ILoggingService logger;

		[HttpGet("next")]
		[Produces("application/json", Type = typeof(NextRaceSummary))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetNextRace()
		{
			try
			{
				var nextRace = await service.GetNextRace();
				return this.NotFoundResultIfNull(nextRace);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("last")]
		[Produces("application/json", Type = typeof(LastRaceSummary))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetLastRace()
		{
			try
			{
				var lastRace = await service.GetLastRace();
				return this.NotFoundResultIfNull(lastRace);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public RacesController(IRacesService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
