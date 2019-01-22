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
		public async Task<RaceEntriesInformation> GetRaceEntries([FromQuery(Name = "raceId")] int raceId)
		{
			try
			{
				return await service.GetRaceEntries(raceId);
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
