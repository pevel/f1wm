using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class EntriesController : ControllerBase
	{
		private readonly IEntriesService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceEntriesInformation>> GetRaceEntries(
			[FromQuery(Name = "raceId")] int raceId)
		{
			try
			{
				var entries = await service.GetRaceEntries(raceId);
				return this.NotFoundResultIfNull(entries);
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
