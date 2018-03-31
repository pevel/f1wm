using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.Repositories;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySqlConnector.Logging;
using Narochno.BBCode;

namespace F1WM
{
	public class Startup
	{
		private const string connectionStringKey = "DefaultConnectionString";
		private const string corsPolicy = "DefaultPolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddMvcCore()
				.AddApiExplorer()
				.AddAuthorization()
				.AddDataAnnotations()
				.AddFormatterMappings()
				.AddCors(o => o.AddPolicy(corsPolicy, builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials();
				}))
				.AddJsonFormatters();

			services
				.AddLogging()
				.AddMemoryCache();

			ConfigureRepositories(services);
			ConfigureLogicServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			IConfigurationBuilder configurationBuilder)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				configurationBuilder.AddUserSecrets<Startup>();
			}

			app.UseCors(corsPolicy);
			app.UseMvc();
		}

		private void ConfigureRepositories(IServiceCollection services)
		{
			services.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>();
			services.AddSingleton<SqlStringBuilder>();
			services.AddTransient<IDbContext, DbContext>(BuildDbContext);
			services.AddTransient<INewsRepository, NewsRepository>();
		}

		private void ConfigureLogicServices(IServiceCollection services)
		{
			services.AddSingleton<IBBCodeParser, BBCodeParser>();
			services.AddTransient<INewsService, NewsService>();
			services.AddTransient<IHealthCheckService, HealthCheckService>();
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
	}
}