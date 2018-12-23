using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
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
		public async Task<IActionResult> GetNextRace()
		{
			try
			{
				var nextRace = await service.GetNextRace();
				if (nextRace != null)
				{
					return Ok(nextRace);
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

		[HttpGet("last")]
		[Produces("application/json", Type = typeof(LastRaceSummary))]
		public async Task<IActionResult> GetLastRace()
		{
			try
			{
				var lastRace = await service.GetLastRace();
				if (lastRace != null)
				{
					return Ok(lastRace);
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

		public RacesController(IRacesService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}