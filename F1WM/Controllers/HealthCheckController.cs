using System;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class HealthCheckController : ControllerBase
	{
		private readonly IHealthCheckService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[ProducesResponseType(200)]
		public HealthCheck CheckHealth()
		{
			try
			{
				return new HealthCheck() { DatabaseStatus = service.GetDatabaseStatus() };
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public HealthCheckController(IHealthCheckService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
