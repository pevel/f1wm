using System;
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
		private readonly ILoggingService logger;

		[HttpGet("race/{raceId}")]
		[Produces("application/json", Type = typeof(RaceResult))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetRaceResult(int raceId)
		{
			try
			{
				var raceResult = await service.GetRaceResult(raceId);
				return this.NotFoundResultIfNull(raceResult);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("qualifying/{raceId}")]
		[Produces("application/json", Type = typeof(QualifyingResult))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetQualifyingResult(int raceId)
		{
			try
			{
				var qualifyingResult = await service.GetQualifyingResult(raceId);
				return this.NotFoundResultIfNull(qualifyingResult);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("practice/{raceId}/sessions/{session}")]
		[Produces("application/json", Type = typeof(PracticeSessionResult))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetPracticeSessionResult(int raceId, string session)
		{
			try
			{
				var result = await service.GetPracticeSessionResult(raceId, session);
				return this.NotFoundResultIfNull(result);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("other/{eventId}")]
		[Produces("application/json", Type = typeof(OtherResult))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetOtherResult(int eventId)
		{
			try
			{
				var result = await service.GetOtherResult(eventId);
				return this.NotFoundResultIfNull(result);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public ResultsController(IResultsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
