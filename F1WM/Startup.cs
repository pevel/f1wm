using System;
using System.IdentityModel.Tokens.Jwt;
using F1WM.DatabaseModel;
using F1WM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;

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
					.AddMvcCore()
					.AddApiExplorer()
					.AddAuthorization()
					.AddDataAnnotations()
					.AddFormatterMappings()
					.AddCustomCors()
					.AddJsonFormatters()
					.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
				services
					.AddLogging()
					.AddSwagger()
					.AddTransient<ILoggingService, LoggingService>(provider => this.logger)
					.AddMemoryCache()
					.ConfigureRepositories(configuration)
					.ConfigureLogicServices()
					.AddIdentity<F1WMUser, IdentityRole>()
					.AddEntityFrameworkStores<F1WMIdentityContext>()
					.AddDefaultTokenProviders();
				services
					.AddCustomAuth(configuration);
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
					.UseCustomForwardedHeaders()
					.UseCors(Configuration.CorsPolicy)
					.UseCustomSwaggerUi(environment)
					.UseMvc()
					.UseAuthentication();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}
	}
}