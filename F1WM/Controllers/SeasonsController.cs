using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class SeasonsController : ControllerBase
	{
		private readonly ISeasonsService service;
		private readonly ILoggingService logger;

		[HttpGet("rules")]
		[Produces("application/json", Type = typeof(SeasonRules))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetSeasonRules([FromQuery(Name = "year")] int? year)
		{
			try
			{
				var seasonRules = await service.GetSeasonRules(year);
				return this.NotFoundResultIfNull(seasonRules);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public SeasonsController(ISeasonsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
