using System;
using F1WM.Repositories;
using F1WM.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F1WM
{
	public static class RepositoriesStartup
	{
		private const string connectionStringKey = "DefaultConnectionString";

		public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			return services
				.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>()
				.AddSingleton<SqlStringBuilder>()
				.AddTransient<IDbContext, DbContext>(provider => BuildDbContext(configuration))
				.AddTransient<INewsRepository, NewsRepository>()
				.AddTransient<ICommentsRepository, CommentsRepository>();
		}

		private static DbContext BuildDbContext(IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString(connectionStringKey);
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new SystemException("Database connection string is missing in configuration.");
			}
			return new DbContext(connectionString);
		}
	}
}