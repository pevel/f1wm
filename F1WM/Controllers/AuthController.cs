using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace F1WM.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService service;
		private readonly IConfiguration configuration;
		private readonly ILoggingService logger;

		[HttpPost]
		[Produces("application/json", Type = typeof(Tokens))]
		public async Task<IActionResult> Login([FromBody]Login login)
		{
			try
			{
				var result = await service.SignIn(login.Email, login.Password);
				if (result.Succeeded)
				{
					var tokens = await service.GenerateTokens(login.Email);
					return Ok(tokens);
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
		[Produces("application/json", Type = typeof(Tokens))]
		public async Task<IActionResult> Register([FromBody]RegisterRequest request)
		{
			try
			{
				var user = new F1WMUser()
				{
					UserName = request.Email,
					Email = request.Email
				};
				if (request.Key == configuration[Configuration.RegisterKeyKey])
				{
					var result = await service.SignUp(user, request.Password);
					if (result.Succeeded)
					{
						var tokens = await service.GenerateTokens(request.Email);
						return Ok(tokens);
					}
					else
					{
						return UnprocessableEntity(result.Errors);
					}
				}
				else
				{
					return UnprocessableEntity();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpPost]
		[Produces("application/json", Type = typeof(Tokens))]
		public async Task<IActionResult> RefreshAccessToken([FromBody]Tokens tokens)
		{
			try
			{
				if (service.TryGetEmailFromTokens(tokens, out var email))
				{
					var accessToken = await service.GenerateAccessToken(email);
					return Ok(new Tokens()
					{
						AccessToken = accessToken,
						RefreshToken = tokens.RefreshToken
					});
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

		public AuthController(IAuthService service, IConfiguration configuration, ILoggingService logger)
		{
			this.service = service;
			this.configuration = configuration;
			this.logger = logger;
		}
	}
}