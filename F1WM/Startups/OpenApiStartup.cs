using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;

namespace F1WM.Startups
{
	public static class OpenApiStartup
	{
		public static IApplicationBuilder UseCustomSwaggerUi(this IApplicationBuilder builder, IWebHostEnvironment environment)
		{
			return builder
				.UseOpenApi(GetOpenApiDocumentSettings(!environment.IsDevelopment()))
				.UseSwaggerUi3();
		}

		public static Action<AspNetCoreOpenApiDocumentGeneratorSettings> GetOpenApiGeneratorSettings()
		{
			return settings =>
			{
				settings.Title = "F1WM web API";
				settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
				settings.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
				new OpenApiSecurityScheme
				{
					Type = OpenApiSecuritySchemeType.ApiKey,
					Name = "Authorization",
					Description = "Copy 'Bearer ' + valid JWT token into field",
					In = OpenApiSecurityApiKeyLocation.Header
				}));
			};
		}

		private static Action<OpenApiDocumentMiddlewareSettings> GetOpenApiDocumentSettings(bool httpsEnabled)
		{
			return settings =>
			{
				if (httpsEnabled)
				{
					settings.PostProcess = (document, request) => document.Schemes = new[] { OpenApiSchema.Https };
				}
			};
		}
	}
}
