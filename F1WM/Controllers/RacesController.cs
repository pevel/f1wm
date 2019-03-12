using System;
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

		[HttpGet("{raceId}/news")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceNews>> GetRaceNews(int raceId)
		{
			var raceNews = await service.GetRaceNews(raceId);
			return this.NotFoundResultIfNull(raceNews);
		}

		[HttpGet("{raceId}/fastest-laps")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceFastestLaps>> GetRaceFastestLaps(int raceId)
		{
			var fastestLaps = await service.GetRaceFastestLaps(raceId);
			return this.NotFoundResultIfNull(fastestLaps);
		}

		[HttpGet("{raceId}/standings/constructors")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<ConstructorsStandingsAfterRace>> GetConstructorsStandingsAfterRace(int raceId)
		{
			throw new NotImplementedException();
		}


		[HttpGet("{raceId}/standings/drivers")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<DriversStandingsAfterRace>> GetDriversStandingsAfterRace(int raceId)
		{
			throw new NotImplementedException();
		}

		public RacesController(IRacesService service)
		{
			this.service = service;
		}
	}
}
