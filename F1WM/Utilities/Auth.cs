using System;
using System.Text;
using F1WM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace F1WM.Utilities
{
	public static class Auth
	{
		public static SymmetricSecurityKey GetJwtKey(IConfiguration configuration)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Configuration.JwtKeyKey]));
		}

		public static DateTime GetAccessTokenExpiration(IConfiguration configuration, ITimeService time)
		{
			return time.Now.ToUniversalTime().AddSeconds(double.Parse(configuration[Configuration.JwtExpireSecondsKey]));
		}

		public static DateTime GetRefreshTokenExpiration(ITimeService time)
		{
			return time.Now.ToUniversalTime().AddDays(10);
		}

		public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
		{
			return new TokenValidationParameters()
			{
				ValidIssuer = configuration[Configuration.JwtIssuerKey],
				ValidAudience = configuration[Configuration.JwtAudienceKey],
				IssuerSigningKey = Auth.GetJwtKey(configuration),
				ClockSkew = TimeSpan.Zero
			};
		}

		public static TokenValidationParameters GetLooseValidationParameters(IConfiguration configuration)
		{
			return new TokenValidationParameters
			{
				ValidIssuer = configuration[Configuration.JwtIssuerKey],
				ValidAudience = configuration[Configuration.JwtAudienceKey],
				IssuerSigningKey = Auth.GetJwtKey(configuration),
				ValidateLifetime = false
			};
		}
	}
}