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
		private readonly ILoggingService logger;

		[HttpGet("next")]
		[Produces("application/json", Type = typeof(BroadcastsInformation))]
		public async Task<IActionResult> GetBroadcasts()
		{
			try
			{
				var info = new BroadcastsInformation();
				if (info != null)
				{
					return Ok(info);
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

		public BroadcastsController(ILoggingService logger)
		{
			this.logger = logger;
		}
	}
}