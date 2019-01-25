using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class GridsController : ControllerBase
	{
		private readonly IGridsService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<GridInformation>> GetGrid(
			[FromQuery(Name = "raceId")] int raceId)
		{
			try
			{
				var grid = await service.GetGrid(raceId);
				return this.NotFoundResultIfNull(grid);
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
