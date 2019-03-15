using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Equivalency;
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
			T actual = await GetResponse(url, expected);
			actual.Should().BeEquivalentTo(expected, why);
		}

		protected async Task TestResponse<T>(
			string url,
			T expected,
			Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config,
			string why = "")
		{
			T actual = await GetResponse(url, expected);
			actual.Should().BeEquivalentTo(expected, config, why);
		}

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
			client = server.CreateClient();
		}

		private async Task<T> GetResponse<T>(string url, T expected)
		{
			Assert.NotNull(expected);
			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var actual = JsonConvert.DeserializeObject<T>(responseContent);
			return actual;
		}
	}
}
