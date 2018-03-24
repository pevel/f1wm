using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace F1WM.IntegrationTests
{
	public abstract class IntegrationTestBase
	{
		protected readonly TestServer server;
		protected readonly HttpClient client;
		protected readonly string baseAddress = "/api";

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
			client = server.CreateClient();
		}
	}
}