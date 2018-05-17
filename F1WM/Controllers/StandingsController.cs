using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class StandingsController : ControllerBase
	{
		private IStandingsService service;
		private ILoggingService logger;

		[HttpGet("constructors")]
		public async Task<IActionResult> GetConstructorsStandings()
		{
			throw new NotImplementedException();
		}

		[HttpGet("drivers")]
		public async Task<IActionResult> GetDriversStandings()
		{
			throw new NotImplementedException();
		}

		public StandingsController(IStandingsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}