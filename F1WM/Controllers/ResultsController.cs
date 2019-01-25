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
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<RaceResult>> GetRaceResult(int raceId)
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
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<QualifyingResult>> GetQualifyingResult(int raceId)
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
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<PracticeSessionResult>> GetPracticeSessionResult(int raceId, string session)
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
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<OtherResult>> GetOtherResult(int eventId)
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
