using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class ResultsController : ControllerBase
	{
		private readonly IResultsService service;

		[HttpGet("race/{raceId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceResult>> GetRaceResult(int raceId)
		{
			var raceResult = await service.GetRaceResult(raceId);
			return this.NotFoundResultIfNull(raceResult);
		}

		[HttpGet("qualifying/{raceId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<QualifyingResult>> GetQualifyingResult(int raceId)
		{
			var qualifyingResult = await service.GetQualifyingResult(raceId);
			return this.NotFoundResultIfNull(qualifyingResult);
		}

		[HttpGet("practice/{raceId}/sessions/{session}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<PracticeSessionResult>> GetPracticeSessionResult(int raceId, string session)
		{
			var result = await service.GetPracticeSessionResult(raceId, session);
			return this.NotFoundResultIfNull(result);
		}

		[HttpGet("other/{eventId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<OtherResult>> GetOtherResult(int eventId)
		{
			var result = await service.GetOtherResult(eventId);
			return this.NotFoundResultIfNull(result);
		}

		public ResultsController(IResultsService service)
		{
			this.service = service;
		}
	}
}
