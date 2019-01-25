using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
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
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Drivers>> GetDrivers(
			[FromQuery(Name = "letter")]char letter)
		{
			try
			{
				if (letter == '\0') return BadRequest();

				var drivers = await service.GetDrivers(letter);
				return this.NotFoundResultIfNull(drivers);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<DriverDetails>> GetDriver(
			[FromRoute]int id,
			[FromQuery]int? atYear)
		{
			try
			{
				var driver = await service.GetDriver(id, atYear);
				return this.NotFoundResultIfNull(driver);
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
