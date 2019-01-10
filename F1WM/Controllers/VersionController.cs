using System;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class VersionController : ControllerBase
	{
		private readonly IVersioningService service;
		private readonly ILoggingService logger;

		[HttpGet]
		public ApiVersion GetVersion()
		{
			try
			{
				return service.GetApiVersion();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public VersionController(IVersioningService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}