using System;
using System.Reflection;
using F1WM.Repositories;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Narochno.BBCode;
using NJsonSchema;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.WebApi;

namespace F1WM
{
	public class Startup
	{
		private const string connectionStringKey = "DefaultConnectionString";
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
					.AddJsonFormatters();

				services
					.AddLogging()
					.AddMemoryCache();

				ConfigureRepositories(services);
				ConfigureLogicServices(services);
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
					.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, GetSwaggerUiSettings())
					.UseMvc();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		private void ConfigureRepositories(IServiceCollection services)
		{
			services.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>();
			services.AddSingleton<SqlStringBuilder>();
			services.AddTransient<IDbContext, DbContext>(BuildDbContext);
			services.AddTransient<INewsRepository, NewsRepository>();
			services.AddTransient<ICommentsRepository, CommentsRepository>();
		}

		private void ConfigureLogicServices(IServiceCollection services)
		{
			services.AddSingleton<IBBCodeParser, BBCodeParser>();
			services.AddTransient<INewsService, NewsService>();
			services.AddTransient<IHealthCheckService, HealthCheckService>();
			services.AddTransient<ICommentsService, CommentsService>();
			services.AddTransient<ILoggingService, LoggingService>(provider => this.logger);
			services.AddSingleton<ICachingService, CachingService>();
		}

		private DbContext BuildDbContext(IServiceProvider serviceProvider)
		{
			var connectionString = Configuration.GetConnectionString(connectionStringKey);
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new SystemException("Database connection string is missing in configuration.");
			}
			return new DbContext(connectionString);
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

		private Action<SwaggerUiSettings<WebApiToSwaggerGeneratorSettings>> GetSwaggerUiSettings()
		{
			return settings =>
			{
				settings.GeneratorSettings.Title = "F1WM web API";
				settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
			};
		}
	}
}