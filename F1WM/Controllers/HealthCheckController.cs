using F1WM.Model;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class HealthCheckController : Controller
	{
		[HttpGet]
		public HealthCheck CheckHealth()
		{
			return new HealthCheck();
		}
	}
}