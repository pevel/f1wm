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
		}

		private DbContext BuildDbContext(IServiceProvider serviceProvider)
		{
			return new DbContext(Configuration.GetConnectionString(connectionStringKey));
		}
	}
}