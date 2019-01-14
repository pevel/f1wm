using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
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
		public async Task<IActionResult> GetTrackRecords(int trackId, int trackVersion, [FromQuery]int? beforeYear)
		{
			try
			{
				var records = await service.GetTrackRecords(trackId, trackVersion, beforeYear);
				if (records != null)
				{
					return Ok(records);
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

		public TracksController(ITracksService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
