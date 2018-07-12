using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class RacesController : ControllerBase
	{

		private IRacesService service;
		private ILoggingService logger;

		[HttpGet("next")]
		[Produces("application/json", Type = typeof(NextRaceSummary))]
		public async Task<NextRaceSummary> GetNextRace()
		{
			try
			{
				return await service.GetNextRace();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public RacesController(IRacesService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}