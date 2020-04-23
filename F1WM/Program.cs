using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace F1WM
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateWebHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureKestrel(serverOptions => {})
						.UseStartup<Startup>()
						.UseSerilog();
				});
	}
}
