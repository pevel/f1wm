using System;
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
		private readonly ILoggingService logger;

		[HttpGet("{trackId}/versions/{trackVersion}/records")]
		[Produces("application/json", Type = typeof(TrackRecordsInformation))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetTrackRecords(int trackId, int trackVersion, [FromQuery]int? beforeYear)
		{
			try
			{
				var records = await service.GetTrackRecords(trackId, trackVersion, beforeYear);
				return this.NotFoundResultIfNull(records);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public TracksController(ITracksService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
