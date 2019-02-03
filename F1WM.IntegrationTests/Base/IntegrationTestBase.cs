using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public abstract class IntegrationTestBase
	{
		protected readonly TestServer server;
		protected readonly HttpClient client;
		protected readonly string baseAddress = "/api";

		protected async Task TestResponse<T>(string url, T expected, string why = "")
		{
			Assert.NotNull(expected);
			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var actual = JsonConvert.DeserializeObject<T>(responseContent);
			actual.Should().BeEquivalentTo(expected, why);
		}

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
			client = server.CreateClient();
		}
	}
}
