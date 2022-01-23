using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class CachingController : ControllerBase
	{
		private readonly ICachingService service;

		[HttpDelete]
		[ProducesResponseType(204)]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		public ActionResult ClearCache()
		{
			service.DisposeCache();
			return NoContent();
		}

		public CachingController(ICachingService service)
		{
			this.service = service;
		}
	}
}
