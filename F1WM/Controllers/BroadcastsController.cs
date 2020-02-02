using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
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
			[FromBody] BroadcastsAddRequest request)
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

		[HttpGet("broadcasted-races/{raceId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<BroadcastedRace>> GetBroadcastedRace([FromRoute] int raceId)
		{
			var race = await service.GetBroadcastedRace(raceId);
			return this.NotFoundResultIfNull(race);
		}

		[HttpPatch("broadcasted-races/{raceId}")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<BroadcastedRace>> UpdateBroadcasts(
			[FromBody] JsonPatchDocument<BroadcastedRaceUpdate> patchDocument, [FromRoute] int raceId)
		{
			try
			{
				var broadcasts = await service.UpdateBroadcasts(new BroadcastsUpdateRequest() { RaceId = raceId, PatchDocument = patchDocument });
				return this.NotFoundResultIfNull(broadcasts);
			}
			catch (JsonPatchException ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("broadcasted-races/{raceId}")]
		[Authorize]
		[ProducesResponseType(204)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult> DeleteBroadcasts([FromRoute] int raceId)
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
			[FromBody] BroadcasterAddRequest request)
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

		[HttpPatch("broadcasters/{id}")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Broadcaster>> UpdateBroadcaster(
			[FromRoute] int id, [FromBody] JsonPatchDocument<Broadcaster> patchDocument)
		{
			try
			{
				var broadcaster = await service.UpdateBroadcaster(
					new BroadcasterUpdateRequest() { Id = id, PatchDocument = patchDocument });
				return this.NotFoundResultIfNull(broadcaster);
			}
			catch (JsonPatchException ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
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
			[FromBody] BroadcastSessionTypeAddRequest request)
		{
			var type = await service.AddSessionType(request);
			return CreatedAtAction(nameof(GetSessionTypes), type);
		}

		[HttpPatch("types/{id}")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<BroadcastSessionType>> UpdateSessionType(
			[FromRoute] int id, [FromBody] JsonPatchDocument<BroadcastSessionType> patchDocument)
		{
			try
			{
				var type = await service.UpdateSessionType(
					new BroadcastSessionTypeUpdateRequest() { Id = id, PatchDocument = patchDocument });
				return this.NotFoundResultIfNull(type);
			}
			catch (JsonPatchException ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
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
