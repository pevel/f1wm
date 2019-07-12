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
using NSwag.AspNetCore;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace F1WM
{
	public class Startup
	{
		private readonly IConfiguration configuration;
		private readonly IHostingEnvironment environment;
		private LoggingService logger;

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
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
					.AddSwagger()
					.AddTransient<ILoggingService, LoggingService>(provider => this.logger)
					.AddMemoryCache()
					.AddResponseCaching()
					.ConfigureRepositories(configuration)
					.ConfigureLogicServices()
					.AddIdentity<F1WMUser, IdentityRole>()
					.AddEntityFrameworkStores<F1WMIdentityContext>()
					.AddDefaultTokenProviders();
				services
					.AddCustomAuth(environment, configuration);
				services
					.AddMvcCore()
					.AddApiExplorer()
					.AddAuthorization()
					.AddDataAnnotations()
					.AddFormatterMappings()
					.AddCustomCors()
					.AddJsonFormatters()
					.AddXmlSerializerFormatters()
					.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
					.UseMiddleware<ExceptionMiddleware>()
					.UseCustomForwardedHeaders()
					.UseResponseCaching()
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
