using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class DriversController : ControllerBase
	{
		private readonly IDriversService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[Produces("application/json", Type = typeof(DriversList))]
		public async Task<IActionResult> GetDrivers([FromQuery(Name = "letter")] string letter)
		{
			try
			{
				var drivers = await service.GetDrivers(letter);
				if (drivers != null)
				{
					return Ok(drivers);
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

		public DriversController(IDriversService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}

