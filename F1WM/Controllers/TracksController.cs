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

		[HttpGet("{trackId}/versions/{trackVersion}/records")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TrackRecordsInformation>> GetTrackRecords(
			[FromRoute]int trackId,
			[FromRoute]int trackVersion,
			[FromQuery]int? beforeYear)
		{
			var records = await service.GetTrackRecords(trackId, trackVersion, beforeYear);
			return this.NotFoundResultIfNull(records);
		}

		[HttpGet]
		public async Task<PagedResult<Track>> GetTracks(
			[FromQuery]byte? statusId, 
			[FromQuery(Name = "page")] uint page = defaultPage,
			[FromQuery(Name = "countPerPage")] uint countPerPage = defaultCountPerPage)
		{
			if (statusId != null)
			{
				return await service.GetTracksByStatusId((byte)statusId, page, countPerPage);
			}
			else
			{
				return await service.GetTracks(page, countPerPage);
			}
		}

			public TracksController(ITracksService service)
		{
			this.service = service;
		}
	}
}
