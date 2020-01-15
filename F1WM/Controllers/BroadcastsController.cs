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

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<IEnumerable<BroadcastsInformation>> GetBroadcasts(
			[FromQuery] int? raceId)
		{
			return await service.GetBroadcasts(raceId);
		}

		[HttpPost]
		[Authorize]
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
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

		[HttpPatch]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<BroadcastsInformation>> UpdateBroadcasts(
			[FromBody]BroadcastsUpdateRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var broadcast = await service.UpdateBroadcasts(request);
			return Ok(broadcast);
		}

		[HttpDelete]
		[Authorize]
		[ProducesResponseType(204)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult> DeleteBroadcasts([FromQuery] int raceId)
		{
			await service.DeleteBroadcasts(raceId);
			return NoContent();
		}

		[HttpGet("next")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<BroadcastsInformation>> GetNextBroadcasts(
			[FromQuery] DateTime? after)
		{
			var broadcasts = await service.GetNextBroadcasts(after);
			return this.NotFoundResultIfNull(broadcasts);
		}

		[HttpGet("broadcasters")]
		[ProducesResponseType(200)]
		public async Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			return await service.GetBroadcasters();
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

		[HttpPatch("broadcasters")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<IEnumerable<Broadcaster>> UpdateBroadcaster(
			[FromBody]BroadcasterUpdateRequest request)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("broadcasters/{id}")]
		[Authorize]
		[ProducesResponseType(204)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult> DeleteBroadcaster(int id)
		{
			await service.DeleteBroadcaster(id);
			return NoContent();
		}

		[HttpGet("types")]
		[ProducesResponseType(200)]
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

		[HttpPatch("types")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<IEnumerable<Broadcaster>> UpdateSessionType(
			[FromBody]BroadcastSessionTypeUpdateRequest request)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("types/{id}")]
		[Authorize]
		[ProducesResponseType(204)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult> DeleteSessionType(int id)
		{
			await service.DeleteSessionType(id);
			return NoContent();
		}

		public BroadcastsController(IBroadcastsService service)
		{
			this.service = service;
		}
	}
}
