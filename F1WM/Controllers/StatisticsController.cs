using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticsService service;

		[HttpGet("drivers/{driverId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<DriverStatistics>> GetDriverStatistics(
			[FromRoute]int driverId,
			[FromQuery]int? atYear)
		{
			var statistics = await service.GetDriverStatistics(driverId, atYear);
			return this.NotFoundResultIfNull(statistics);
		}

		[HttpGet("teams/{teamId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TeamStatistics>> GetTeamStatistics(
			[FromRoute]int teamId,
			[FromQuery]int? atYear)
		{
			var statistics = await service.GetTeamStatistics(teamId, atYear);
			return this.NotFoundResultIfNull(statistics);
		}

		[HttpGet("engines/{engineId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<EngineStatistics>> GetEngineStatistics(
			[FromRoute]int engineId,
			[FromQuery]int? atYear)
		{
			var statistics = await service.GetEngineStatistics(engineId, atYear);
			return this.NotFoundResultIfNull(statistics);
		}

		public StatisticsController(IStatisticsService service)
		{
			this.service = service;
		}
	}
}
