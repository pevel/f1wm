using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class RacesController : ControllerBase
	{
		private readonly IRacesService service;

		[HttpGet("next")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<NextRaceSummary>> GetNextRace()
		{
			var nextRace = await service.GetNextRace();
			return this.NotFoundResultIfNull(nextRace);
		}

		[HttpGet("last")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<LastRaceSummary>> GetLastRace()
		{
			var lastRace = await service.GetLastRace();
			return this.NotFoundResultIfNull(lastRace);
		}

		public RacesController(IRacesService service)
		{
			this.service = service;
		}
	}
}
