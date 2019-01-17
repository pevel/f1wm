using System;
using F1WM.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM.Startups
{
	public static class AuthStartup
	{
		public static AuthenticationBuilder AddCustomAuth(this IServiceCollection services, IHostingEnvironment environment, IConfiguration configuration)
		{
			return services
				.AddAuthentication(GetAuthenticationOptions())
				.AddJwtBearer(GetJwtBearerOptions(environment, configuration));
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

		private static Action<JwtBearerOptions> GetJwtBearerOptions(IHostingEnvironment environment, IConfiguration configuration)
		{
			return options =>
			{
				options.RequireHttpsMetadata = !environment.IsDevelopment();
				options.SaveToken = true;
				options.TokenValidationParameters = Auth.GetTokenValidationParameters(configuration);
			};
		}
	}
}