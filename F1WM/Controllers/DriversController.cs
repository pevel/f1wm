using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class DriversController : ControllerBase
	{
		private readonly IDriversService service;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Drivers>> GetDrivers(
			[FromQuery(Name = "letter")]char letter)
		{
			if (letter == '\0') return BadRequest();

			var drivers = await service.GetDrivers(letter);
			return this.NotFoundResultIfNull(drivers);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<DriverDetails>> GetDriver(
			[FromRoute]int id,
			[FromQuery]int? atYear)
		{
			var driver = await service.GetDriver(id, atYear);
			return this.NotFoundResultIfNull(driver);
		}

		public DriversController(IDriversService service)
		{
			this.service = service;
		}
	}
}
