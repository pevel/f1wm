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

		public TracksController(ITracksService service)
		{
			this.service = service;
		}
	}
}
