using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class HealthCheckController : ControllerBase
	{
		private readonly IHealthCheckService service;

		[HttpGet]
		[ProducesResponseType(200)]
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
