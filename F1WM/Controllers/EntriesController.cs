using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class EntriesController : ControllerBase
	{
		private readonly IEntriesService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[Produces("application/json", Type = typeof(RaceEntriesInformation))]
		public async Task<IActionResult> GetRaceEntries([FromQuery(Name = "raceId")] int raceId)
		{
			try
			{
				var entries = await service.GetRaceEntries(raceId);
				if (entries != null)
				{
					return Ok(entries);
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

		public EntriesController(IEntriesService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
