using System;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using F1WM.ApiModel;
using System.Threading.Tasks;
using F1WM.DatabaseModel;

namespace F1WM.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService service;
		private readonly ILoggingService logger;

		[HttpPost]
		[Produces("application/json", Type = typeof(string))]
		public async Task<IActionResult> Login([FromBody]Login login)
		{
			try
			{
				var result = await service.SignIn(login.Email, login.Password);
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

		[HttpPost]
		[Produces("application/json", Type = typeof(string))]
		public async Task<IActionResult> Register([FromBody]RegisterRequest request)
		{
			try
			{
				var user = new F1WMUser()
				{
					UserName = request.Email,
					Email = request.Email
				};
				var result = await service.CreateUser(user, request.Password);
				if (result.Succeeded)
				{
					var token = await service.GenerateJwtToken(request.Email);
					return Ok(token);
				}
				else
				{
					return UnprocessableEntity(result.Errors);
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