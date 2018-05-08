using System;
using AutoMapper;
using F1WM.DatabaseModel;
using F1WM.Repositories;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM
{
	public static class RepositoriesStartup
	{
		private const string connectionStringKey = "DefaultConnectionString";

		public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			AutoMapper.ServiceCollectionExtensions.UseStaticRegistration = false;
			return services
				.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>()
				.AddDbContext<F1WMContext>(options => BuildDbContext(options, configuration))
				.AddAutoMapper(options => options.AddProfile(new MappingProfile()))
				.AddTransient<INewsRepository, NewsRepository>()
				.AddTransient<ICommentsRepository, CommentsRepository>()
				.AddTransient<IHealthCheckRepository, HealthCheckRepository>();
		}

		private static void BuildDbContext(DbContextOptionsBuilder options, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString(connectionStringKey);
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new SystemException("Database connection string is missing in configuration.");
			}
			options.UseMySql(connectionString);
		}
	}
}