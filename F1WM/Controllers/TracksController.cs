using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class TracksController : ControllerBase
	{
		private readonly ITracksService service;
		private const int defaultPage = 1;
		private const int defaultCountPerPage = 25;

		[HttpGet]
		public async Task<PagedResult<Track>> GetTracks(
			[FromQuery] byte? status,
			[FromQuery(Name = "page")] int page = defaultPage,
			[FromQuery(Name = "countPerPage")] int countPerPage = defaultCountPerPage)
		{
			if (status != null)
			{
				return await service.GetTracksByStatus((byte)status, page, countPerPage);
			}
			else
			{
				return await service.GetTracks(page, countPerPage);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TrackDetails>> GetTrack(
			[FromRoute] int id,
			[FromQuery] int? atYear)
		{
			var track = await service.GetTrack(id, atYear);
			return this.NotFoundResultIfNull(track);
		}

		[HttpGet("{trackId}/short-results")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TrackShortResultsByYears>> GetShortResultsByYears(
			[FromRoute] int trackId,
			[FromQuery] int? untilYear)
		{
			var shortResults = await service.GetShortResultsByYears(trackId, untilYear);
			return this.NotFoundResultIfNull(shortResults);
		}

		[HttpGet("{trackId}/versions/{trackVersion}/records")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TrackRecordsInformation>> GetTrackRecords(
			[FromRoute] int trackId,
			[FromRoute] int trackVersion,
			[FromQuery] int? beforeYear)
		{
			var records = await service.GetTrackRecords(trackId, trackVersion, beforeYear);
			return this.NotFoundResultIfNull(records);
		}

		public TracksController(ITracksService service)
		{
			this.service = service;
		}
	}
}
