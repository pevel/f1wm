using System;
using F1WM.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM.Startups
{
	public static class AuthStartup
	{
		public static AuthenticationBuilder AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddAuthentication(GetAuthenticationOptions()).AddJwtBearer(GetJwtBearerOptions(configuration));
		}

		private static Action<AuthenticationOptions> GetAuthenticationOptions()
		{
			return options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			};
		}

		private static Action<JwtBearerOptions> GetJwtBearerOptions(IConfiguration configuration)
		{
			return options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = Auth.GetTokenValidationParameters(configuration);
			};
		}
	}
}