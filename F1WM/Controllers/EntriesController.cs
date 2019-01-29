using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class EntriesController : ControllerBase
	{
		private readonly IEntriesService service;

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceEntriesInformation>> GetRaceEntries(
			[FromQuery(Name = "raceId")] int raceId)
		{
			var entries = await service.GetRaceEntries(raceId);
			return this.NotFoundResultIfNull(entries);
		}

		public EntriesController(IEntriesService service)
		{
			this.service = service;
		}
	}
}
