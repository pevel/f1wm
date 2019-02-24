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

		[HttpGet("next")]
		public async Task<ActionResult<BroadcastsInformation>> GetNextBroadcasts()
		{
			var broadcasts = await service.GetNextBroadcasts();
			return this.NotFoundResultIfNull(broadcasts);
		}

		[HttpGet("broadcasters")]
		public async Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			return await service.GetBroadcasters();
		}

		[HttpGet("types")]
		public async Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return await service.GetSessionTypes();
		}

		[HttpPost("types")]
		[Authorize]
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		public async Task<ActionResult<BroadcastSessionType>> AddSessionType(
			[FromBody]BroadcastSessionTypeAddRequest request)
		{
			var type = await service.AddSessionType(request);
			return CreatedAtAction(nameof(GetSessionTypes), type);
		}

		[HttpPost("broadcasters")]
		[Authorize]
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		[ProducesResponseType(422)]
		public async Task<ActionResult<Broadcaster>> AddBroadcaster(
			[FromBody]BroadcasterAddRequest request)
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

		[HttpPost]
		[Authorize]
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		[ProducesResponseType(422)]
		public async Task<ActionResult<BroadcastsInformation>> AddBroadcasts(
			[FromBody]BroadcastsAddRequest request)
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

		public BroadcastsController(IBroadcastsService service)
		{
			this.service = service;
		}
	}
}
