using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.ApiModel.Engines;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{

	[Route("api/[controller]")]
	public class EnginesController : ControllerBase
	{
		private readonly IEnginesService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Engines>> GetEngines(
			[FromQuery(Name = "letter")] char letter)
		{
			try
			{
				if (letter == '\0') return BadRequest();

				var engines = await service.GetEngines(letter);
				return this.NotFoundResultIfNull(engines);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public EnginesController(IEnginesService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
