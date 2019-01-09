using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Repositories;
using F1WM.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace F1WM.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository repository;
		private readonly SignInManager<F1WMUser> signInManager;
		private readonly UserManager<F1WMUser> userManager;
		private readonly IConfiguration configuration;
		private readonly IGuidService guid;
		private readonly ITimeService time;

		public AuthService(
			IAuthRepository repository,
			IConfiguration configuration,
			IGuidService guid,
			ITimeService time,
			SignInManager<F1WMUser> signInManager,
			UserManager<F1WMUser> userManager)
		{
			this.repository = repository;
			this.configuration = configuration;
			this.guid = guid;
			this.time = time;
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		public async Task<string> GenerateAccessToken(string email)
		{
			var user = await repository.GetUserByEmail(email);
			return GenerateToken(user, Auth.GetAccessTokenExpiration(configuration, time));
		}

		public async Task<Tokens> GenerateTokens(string email)
		{
			var user = await repository.GetUserByEmail(email);
			return new Tokens()
			{
				AccessToken = GenerateToken(user, Auth.GetAccessTokenExpiration(configuration, time)),
				RefreshToken = GenerateToken(user, Auth.GetRefreshTokenExpiration(time))
			};
		}

		public Task<SignInResult> SignIn(string email, string password)
		{
			return signInManager.PasswordSignInAsync(email, password, false, false);
		}

		public Task<IdentityResult> SignUp(F1WMUser user, string password)
		{
			return userManager.CreateAsync(user, password);
		}

		public bool TryGetEmailFromTokens(Tokens tokens, out string email)
		{
			var accessValidation = Auth.GetLooseValidationParameters(configuration);
			var refreshValidation = Auth.GetTokenValidationParameters(configuration);
			var handler = new JwtSecurityTokenHandler();
			email = null;
			try
			{
				handler.ValidateToken(tokens.RefreshToken, refreshValidation, out var refreshToken);
				var principal = handler.ValidateToken(tokens.AccessToken, accessValidation, out var accessToken);
				if (refreshToken != null && accessToken != null)
				{
					email = principal.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		private string GenerateToken(F1WMUser user, DateTime expiresAt)
		{
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id)
			};
			var key = Auth.GetJwtKey(configuration);
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				issuer: configuration[Configuration.JwtIssuerKey],
				claims: claims,
				expires: expiresAt,
				audience: configuration[Configuration.JwtAudienceKey],
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}