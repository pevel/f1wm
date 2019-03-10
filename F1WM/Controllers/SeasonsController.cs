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
		private readonly ISeasonsService seasonsService;
		private readonly IEntriesService entriesService;

		[HttpGet("rules")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<SeasonRules>> GetSeasonRules(
			[FromQuery] int? year)
		{
			var seasonRules = await seasonsService.GetSeasonRules(year);
			return this.NotFoundResultIfNull(seasonRules);
		}

		[HttpGet("entries")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<SeasonEntriesInformation>> GetSeasonEntries(
			[FromQuery] int year)
		{
			var entries = await entriesService.GetSeasonEntries(year);
			return this.NotFoundResultIfNull(entries);
		}

		public SeasonsController(ISeasonsService seasonsService, IEntriesService entriesService)
		{
			this.seasonsService = seasonsService;
			this.entriesService = entriesService;
		}
	}
}
