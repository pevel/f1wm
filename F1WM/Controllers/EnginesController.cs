using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{

	[Route("api/[controller]")]
	public class EnginesController : ControllerBase
	{
		private readonly IEnginesService service;

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<EngineDetails>> GetEngine([FromRoute]int id)
		{
			var engine = await service.GetEngine(id);
			return this.NotFoundResultIfNull(engine);
		}

		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Engines>> GetEngines(
			[FromQuery(Name = "letter")] char letter)
		{
			if (letter == '\0') return BadRequest();

			var engines = await service.GetEngines(letter);
			return this.NotFoundResultIfNull(engines);
		}

		public EnginesController(IEnginesService service)
		{
			this.service = service;
		}
	}
}
