using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace F1WM.Services
{
	public class LoggingService : ILoggingService
	{
		public void LogError(Exception ex)
		{
			Log.Error(ex, "");
		}

		public LoggingService(IConfiguration configuration)
		{
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
		}
	}
}