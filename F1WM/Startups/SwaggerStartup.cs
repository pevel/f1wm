using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;

namespace F1WM.Startups
{
	public static class SwaggerStartup
	{
		public static IApplicationBuilder UseCustomSwaggerUi(this IApplicationBuilder builder, IWebHostEnvironment environment)
		{
			return builder.UseSwaggerUi3WithApiExplorer(GetSwaggerUiSettings(!environment.IsDevelopment()));
		}

		private static Action<SwaggerUi3Settings<AspNetCoreToSwaggerGeneratorSettings>> GetSwaggerUiSettings(bool httpsEnabled)
		{
			return settings =>
			{
				if (httpsEnabled)
				{
					settings.PostProcess = (document) => document.Schemes = new [] { SwaggerSchema.Https };
				}
				settings.GeneratorSettings.Title = "F1WM web API";
				settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
				settings.GeneratorSettings.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
				settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
					new SwaggerSecurityScheme
					{
						Type = SwaggerSecuritySchemeType.ApiKey,
						Name = "Authorization",
						Description = "Copy 'Bearer ' + valid JWT token into field",
						In = SwaggerSecurityApiKeyLocation.Header
					}));
			};
		}
	}
}
