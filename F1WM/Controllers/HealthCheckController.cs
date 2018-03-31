using F1WM.Model;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class HealthCheckController : Controller
	{
		private IHealthCheckService service;

		[HttpGet]
		public HealthCheck CheckHealth()
		{
			return new HealthCheck() { DatabaseStatus = service.GetDatabaseStatus() };
		}

		public HealthCheckController(IHealthCheckService service)
		{
			this.service = service;
		}
	}
}