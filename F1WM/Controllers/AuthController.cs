using System;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using F1WM.ApiModel;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService service;
		private readonly ILoggingService logger;

		[HttpPost]
		[AllowAnonymous]
		[Produces("application/json", Type = typeof(string))]
		public async Task<IActionResult> Login([FromBody]Login login)
		{
			try
			{
				var result = await service.PasswordSignInAsync(login.Email, login.Password);
				if (result.Succeeded)
				{
					var token = await service.GenerateJwtToken(login.Email);
					return Ok(token);
				}
				else
				{
					return Unauthorized();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public AuthController(IAuthService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}