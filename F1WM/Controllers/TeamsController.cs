using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class TeamsController : ControllerBase
	{
		private readonly ITeamsService service;
		private readonly ILoggingService logger;

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TeamDetails>> GetTeam([FromRoute]int id)
		{
			try
			{
				var team = await service.GetTeam(id);
				return this.NotFoundResultIfNull(team);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public TeamsController(ITeamsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
