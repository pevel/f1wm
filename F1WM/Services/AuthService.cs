using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
		private const int refreshTokenNumberSize = 64;

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

		public async Task<Tokens> GenerateTokens(string email)
		{
			var user = await repository.GetUserByEmail(email);
			var refreshToken = GenerateRefreshToken(user);
			var dbRefreshToken = new RefreshToken()
			{
				Token = refreshToken,
				IssuedAt = time.Now.ToUniversalTime(),
				ExpiresAt = Auth.GetRefreshTokenExpiration(time),
				UserId = user.Id
			};
			await repository.AddRefreshToken(dbRefreshToken);
			return new Tokens()
			{
				AccessToken = GenerateAccessToken(user),
				RefreshToken = refreshToken
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

		public async Task<Tokens> RefreshAccessToken(Tokens tokens)
		{
			var accessTokenValidation = Auth.GetAccessTokenValidationParameters(configuration);
			var principal = new JwtSecurityTokenHandler().ValidateToken(tokens.AccessToken, accessTokenValidation, out var accessToken);
			if (await repository.IsRefreshTokenValid(tokens.RefreshToken) && accessToken != null)
			{
				var email = principal.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
				var user = await repository.GetUserByEmail(email);
				return new Tokens()
				{
					RefreshToken = tokens.RefreshToken,
					AccessToken = GenerateAccessToken(user)
				};
			}
			else
			{
				throw new UnauthorizedAccessException();
			}
		}

		private string GenerateAccessToken(F1WMUser user)
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
				expires: Auth.GetAccessTokenExpiration(configuration, time),
				audience: configuration[Configuration.JwtAudienceKey],
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private string GenerateRefreshToken(F1WMUser user)
		{
			var randomNumber = new byte[refreshTokenNumberSize];
			RandomNumberGenerator.Create().GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
	}
}
