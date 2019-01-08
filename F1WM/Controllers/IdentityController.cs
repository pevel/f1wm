using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	public class IdentityController : ControllerBase
	{
		private readonly ILoggingService logger;

		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(User.Claims.Select(u => new { u.Type, u.Value }));
		}

		public IdentityController(ILoggingService logger)
		{
			this.logger = logger;
		}
	}
}