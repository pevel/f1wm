using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.Repositories;
using F1WM.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySqlConnector.Logging;

namespace F1WM
{
	public class Startup
	{
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
				.AddCors()
				.AddJsonFormatters();

			services.AddLogging();
			ConfigureDependencyInjection(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory,
			IConfigurationBuilder configurationBuilder)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				configurationBuilder.AddUserSecrets<Startup>();
			}

			app.UseMvc();
			MySqlConnectorLogManager.Provider = new MicrosoftExtensionsLoggingLoggerProvider(loggerFactory);
		}

		private void ConfigureDependencyInjection(IServiceCollection services)
		{
			services.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>();
			services.AddTransient<DbContext>(provider => new DbContext(Configuration.GetConnectionString(Constants.ConnectionStringKey)));
			services.AddTransient<INewsRepository, NewsRepository>();
		}
	}
}