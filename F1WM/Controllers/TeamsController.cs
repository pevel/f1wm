using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class TeamsController : ControllerBase
	{
		private readonly ITeamsService service;

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TeamDetails>> GetTeam([FromRoute]int id)
		{
			var team = await service.GetTeam(id);
			return this.NotFoundResultIfNull(team);
		}

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Teams>> GetTeams([FromQuery]char letter)
		{
			if (letter == '\0') return BadRequest();

			var teams = await service.GetTeams(letter);
			return this.NotFoundResultIfNull(teams);
		}

		public TeamsController(ITeamsService service)
		{
			this.service = service;
		}
	}
}
