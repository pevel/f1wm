using System;
using F1WM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.AspNetCore;

namespace F1WM
{
	public class Startup
	{
		private const string corsPolicy = "DefaultPolicy";
		private LoggingService logger;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			logger = new LoggingService(configuration);
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			try
			{
				services
					.AddMvcCore()
					.AddApiExplorer()
					.AddAuthorization()
					.AddDataAnnotations()
					.AddFormatterMappings()
					.AddCors(o => o.AddPolicy(corsPolicy, GetCorsPolicyBuilder()))
					.AddJsonFormatters()
					.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

				services
					.AddLogging()
					.AddSwagger()
					.AddTransient<ILoggingService, LoggingService>(provider => this.logger)
					.AddMemoryCache()
					.ConfigureRepositories(Configuration)
					.ConfigureLogicServices();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder application,
			IHostingEnvironment environment,
			IServiceProvider serviceProvider,
			IConfigurationBuilder configurationBuilder)
		{
			try
			{
				if (environment.IsDevelopment())
				{
					application.UseDeveloperExceptionPage();
					configurationBuilder.AddUserSecrets<Startup>();
				}
				configurationBuilder.AddEnvironmentVariables();

				application
					.UseForwardedHeaders(GetForwardedHeadersOptions())
					.UseCors(corsPolicy)
					.UseSwaggerUi3WithApiExplorer(GetSwaggerUiSettings(!environment.IsDevelopment()))
					.UseMvc();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		private Action<CorsPolicyBuilder> GetCorsPolicyBuilder()
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

		private ForwardedHeadersOptions GetForwardedHeadersOptions()
		{
			return new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			};
		}

		private Action<SwaggerUi3Settings<AspNetCoreToSwaggerGeneratorSettings>> GetSwaggerUiSettings(bool httpsEnabled)
		{
			return settings =>
			{
				if (httpsEnabled)
				{
					settings.PostProcess = (document) => document.Schemes = new [] { SwaggerSchema.Https };
				}
				settings.GeneratorSettings.Title = "F1WM web API";
				settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
			};
		}
	}
}