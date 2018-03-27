using F1WM.Model;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class VersionController : Controller
	{
		private readonly ApiVersion version = new ApiVersion() { Version = "0.0.1" };

		[HttpGet]
		public ApiVersion GetVersion()
		{
			return version;
		}
	}
}