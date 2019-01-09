using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
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

		public async Task<string> GenerateJwtToken(string email)
		{
			var user = await repository.GetUserByEmail(email);
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Sub, email),
				new Claim(JwtRegisteredClaimNames.Jti, guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id)
			};
			var key = Auth.GetJwtKey(configuration);
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = time.Now.ToUniversalTime().AddSeconds(double.Parse(configuration[Configuration.JwtExpireSecondsKey]));
			var token = new JwtSecurityToken(
				issuer: configuration[Configuration.JwtIssuerKey],
				claims: claims,
				expires: expires,
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public Task<SignInResult> SignIn(string email, string password)
		{
			return signInManager.PasswordSignInAsync(email, password, false, false);
		}

		public Task<IdentityResult> CreateUser(F1WMUser user, string password)
		{
			return (userManager.CreateAsync(user, password));
		}
	}
}