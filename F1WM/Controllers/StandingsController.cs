using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class StandingsController : ControllerBase
	{
		private const int defaultConstructorsStandingsCount = 10;
		private const int defaultDriversStandingsCount = 10;

		private readonly IStandingsService service;

		[HttpGet("constructors")]
		public async Task<ActionResult<ConstructorsStandings>> GetConstructorsStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultConstructorsStandingsCount)
		{
			var standings = await service.GetConstructorsStandings(count, seasonId);
			return Ok(standings);
		}

		[HttpGet("drivers")]
		public async Task<ActionResult<DriversStandings>> GetDriversStandings(
			[FromQuery(Name = "seasonId")] int? seasonId = null,
			[FromQuery(Name = "count")] int count = defaultDriversStandingsCount)
		{
			var standings = await service.GetDriversStandings(count, seasonId);
			return Ok(standings);
		}

		public StandingsController(IStandingsService service)
		{
			this.service = service;
		}
	}
}
