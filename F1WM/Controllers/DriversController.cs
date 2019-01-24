using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class DriversController : ControllerBase
	{
		private readonly IDriversService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[Produces("application/json", Type = typeof(Drivers))]
		public async Task<IActionResult> GetDrivers([FromQuery(Name = "letter")] char letter)
		{
			try
			{
				if (letter == '\0') return BadRequest();

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

		[HttpGet("{id}")]
		[Produces("application/json", Type = typeof(DriverDetails))]
		public async Task<IActionResult> GetDriver(int id)
		{
			try
			{
				var driver = await service.GetDriver(id);
				if (driver != null)
				{
					return Ok(driver);
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

