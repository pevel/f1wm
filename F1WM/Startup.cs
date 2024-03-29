using System;
using System.IdentityModel.Tokens.Jwt;
using F1WM.DatabaseModel;
using F1WM.Middlewares;
using F1WM.Services;
using F1WM.Startups;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
[assembly: ApiController]
namespace F1WM
{
	public class Startup
	{
		private readonly IConfiguration configuration;
		private readonly IWebHostEnvironment environment;
		private LoggingService logger;

		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			this.configuration = configuration;
			this.environment = environment;
			logger = new LoggingService(configuration);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			try
			{
				JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
				services
					.AddLogging()
					.AddOpenApiDocument(OpenApiStartup.GetOpenApiGeneratorSettings())
					.AddTransient<ILoggingService, LoggingService>(provider => this.logger)
					.AddMemoryCache(o =>
					{
						o.SizeLimit = 500;
					})
					.ConfigureRepositories(configuration)
					.ConfigureLogicServices()
					.AddIdentity<F1WMUser, IdentityRole>()
					.AddEntityFrameworkStores<F1WMIdentityContext>()
					.AddDefaultTokenProviders();
				services
					.AddCustomAuth(environment, configuration);
				services
					.AddMvcCore(options => options.EnableEndpointRouting = false)
					.AddApiExplorer()
					.AddAuthorization()
					.AddDataAnnotations()
					.AddFormatterMappings()
					.AddCustomCors()
					.AddNewtonsoftJson()
					.AddXmlSerializerFormatters();
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
			IWebHostEnvironment environment,
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
				else
				{
					application.UseHttpsRedirection();
				}
				configurationBuilder.AddEnvironmentVariables();
				application
					.UseMiddleware<ExceptionMiddleware>()
					.UseCustomForwardedHeaders()
					.UseCors(Configuration.CorsPolicy)
					.UseCustomSwaggerUi(environment)
					.UseAuthentication()
					.UseMvc();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}
	}
}
