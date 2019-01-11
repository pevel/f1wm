using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("broadcasters")]
		public async Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			try
			{
				return await service.GetBroadcasters();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("types")]
		public async Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			try
			{
				return await service.GetSessionTypes();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpPost("types")]
		[Authorize]
		[Produces("application/json", Type = typeof(BroadcastSessionType))]
		public async Task<IActionResult> AddSessionType([FromBody]BroadcastSessionTypeAddRequest request)
		{
			try
			{
				var type = await service.AddSessionType(request);
				return CreatedAtAction(nameof(GetSessionTypes), type);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpPost("broadcasters")]
		[Authorize]
		[Produces("application/json", Type = typeof(Broadcaster))]
		public async Task<IActionResult> AddBroadcaster([FromBody]BroadcasterAddRequest request)
		{
			try
			{
				var broadcaster = await service.AddBroadcaster(request);
				if (broadcaster != null)
				{
					return CreatedAtAction(nameof(GetBroadcasters), broadcaster);
				}
				else
				{
					return UnprocessableEntity();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpPost]
		[Authorize]
		[Produces("application/json", Type = typeof(BroadcastsInformation))]
		public async Task<IActionResult> AddBroadcasts([FromBody]BroadcastsAddRequest request)
		{
			try
			{
				var broadcasts = await service.AddBroadcasts(request);
				if (broadcasts != null)
				{
					return CreatedAtAction(nameof(GetNextBroadcasts), broadcasts);
				}
				else
				{
					return UnprocessableEntity();
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
