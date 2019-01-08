using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class BroadcastsController : ControllerBase
	{
		private readonly IBroadcastsService service;
		private readonly ILoggingService logger;

		[HttpGet("next")]
		[Produces("application/json", Type = typeof(BroadcastsInformation))]
		public async Task<IActionResult> GetNextBroadcasts()
		{
			try
			{
				var broadcasts = await service.GetNextBroadcasts();
				if (broadcasts != null)
				{
					return Ok(broadcasts);
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

		public BroadcastsController(IBroadcastsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}