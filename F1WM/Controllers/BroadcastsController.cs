using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
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
		public async Task<ActionResult<BroadcastsInformation>> GetNextBroadcasts()
		{
			try
			{
				var broadcasts = await service.GetNextBroadcasts();
				return this.NotFoundResultIfNull(broadcasts);
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
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		public async Task<ActionResult<BroadcastSessionType>> AddSessionType(
			[FromBody]BroadcastSessionTypeAddRequest request)
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
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		[ProducesResponseType(422)]
		public async Task<ActionResult<Broadcaster>> AddBroadcaster(
			[FromBody]BroadcasterAddRequest request)
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
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		[ProducesResponseType(422)]
		public async Task<ActionResult<BroadcastsInformation>> AddBroadcasts(
			[FromBody]BroadcastsAddRequest request)
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
