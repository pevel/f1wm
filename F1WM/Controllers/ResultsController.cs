using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
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
		public async Task<IActionResult> GetRaceResult(int raceId)
		{
			try
			{
				var raceResult = await service.GetRaceResult(raceId);
				if (raceResult != null)
				{
					return Ok(raceResult);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("qualifying/{raceId}")]
		[Produces("application/json", Type = typeof(QualifyingResult))]
		public async Task<IActionResult> GetQualifyingResult(int raceId)
		{
			try
			{
				var qualifyingResult = await service.GetQualifyingResult(raceId);
				if (qualifyingResult != null)
				{
					return Ok(qualifyingResult);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("practice/{id}")]
		[Produces("application/json", Type = typeof(PracticeResult))]
		public async Task<IActionResult> GetPracticeResult(int id)
		{
			try
			{
				var result = await service.GetPracticeResult(id);
				if (result != null)
				{
					return Ok(result);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("other/{id}")]
		[Produces("application/json", Type = typeof(OtherResult))]
		public async Task<IActionResult> GetOtherResult(int id)
		{
			try
			{
				var result = await service.GetOtherResult(id);
				if (result != null)
				{
					return Ok(result);
				}
				else
				{
					return NotFound();
				}
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