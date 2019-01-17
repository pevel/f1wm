using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM.Startups
{
	public static class ServerStartup
	{
		public static IApplicationBuilder UseCustomForwardedHeaders(this IApplicationBuilder builder)
		{
			return builder.UseForwardedHeaders(GetForwardedHeadersOptions());
		}

		public static IMvcCoreBuilder AddCustomCors(this IMvcCoreBuilder builder)
		{
			return builder.AddCors(o => o.AddPolicy(Configuration.CorsPolicy, GetCorsPolicyBuilder()));
		}

		private static Action<CorsPolicyBuilder> GetCorsPolicyBuilder()
		{
			return builder =>
			{
				builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			};
		}

		private static ForwardedHeadersOptions GetForwardedHeadersOptions()
		{
			return new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			};
		}
	}
}