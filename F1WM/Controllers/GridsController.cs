using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class GridsController : ControllerBase
	{
		private readonly IGridsService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[Produces("application/json", Type = typeof(GridInformation))]
		public async Task<IActionResult> GetGrid([FromQuery(Name = "raceId")] int raceId)
		{
			try
			{
				var grid = await service.GetGrid(raceId);
				if (grid != null)
				{
					return Ok(grid);
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

		public GridsController(IGridsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
