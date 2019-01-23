using System;
using System.Reflection;
using AutoMapper;
using F1WM.DatabaseModel;
using F1WM.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM.Startups
{
	public static class RepositoriesStartup
	{
		public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			return services
				.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>()
				.AddDbContext<F1WMContext>(options => BuildDbContext(options, configuration, Configuration.F1WMConnectionStringKey))
				.AddDbContext<F1WMIdentityContext>(options => BuildDbContext(options, configuration, Configuration.F1WMIdentityConnectionStringKey))
				.AddAutoMapper(options => options.AddProfiles(Assembly.GetExecutingAssembly()))
				.AddTransient<INewsRepository, NewsRepository>()
				.AddTransient<ICommentsRepository, CommentsRepository>()
				.AddTransient<IHealthCheckRepository, HealthCheckRepository>()
				.AddTransient<IStandingsRepository, StandingsRepository>()
				.AddTransient<IRacesRepository, RacesRepository>()
				.AddTransient<ICalendarRepository, CalendarRepository>()
				.AddTransient<IResultsRepository, ResultsRepository>()
				.AddTransient<IConfigTextRepository, ConfigTextRepository>()
				.AddTransient<IBroadcastsRepository, BroadcastRepository>()
				.AddTransient<IAuthRepository, AuthRepository>()
				.AddTransient<ISeasonsRepository, SeasonsRepository>()
				.AddTransient<ITracksRepository, TracksRepository>()
				.AddTransient<IDriversRepository, DriversRepository>();
				.AddTransient<IEntriesRepository, EntriesRepository>();
		}

		private static void BuildDbContext(DbContextOptionsBuilder options, IConfiguration configuration, string key)
		{
			var connectionString = configuration.GetConnectionString(key);
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new SystemException("Database connection string is missing in configuration.");
			}
			options.UseMySql(connectionString);
		}
	}
}
