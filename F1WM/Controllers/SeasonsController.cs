using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class SeasonsController : ControllerBase
	{
		private readonly ISeasonsService service;

		[HttpGet("rules")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<SeasonRules>> GetSeasonRules(
			[FromQuery(Name = "year")] int? year)
		{
			var seasonRules = await service.GetSeasonRules(year);
			return this.NotFoundResultIfNull(seasonRules);
		}

		public SeasonsController(ISeasonsService service)
		{
			this.service = service;
		}
	}
}
