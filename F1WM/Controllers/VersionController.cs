using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class VersionController : ControllerBase
	{
		private readonly IVersioningService service;

		[HttpGet]
		[ProducesResponseType(200)]
		public ApiVersion GetVersion()
		{
			return service.GetApiVersion();
		}

		public VersionController(IVersioningService service)
		{
			this.service = service;
		}
	}
}
