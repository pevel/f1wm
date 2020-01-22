using System;
using System.Net.Http;
using System.Threading.Tasks;
using F1WM.ApiModel;
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
		protected readonly SharedLogin.Fixture loginFixture;
		protected readonly TestServer server;
		protected readonly HttpClient client;
		protected readonly string baseAddress = "/api";

		protected async Task TestResponse<T>(string url, T expected, string why = "")
		{
			T actual = await Get<T>(url);
			actual.Should().BeEquivalentTo(expected, why);
		}

		protected async Task TestResponse<T>(
			string url,
			T expected,
			Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config,
			string why = "")
		{
			T actual = await Get<T>(url);
			actual.Should().BeEquivalentTo(expected, config, why);
		}

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
			client = server.CreateClient();
		}

		protected IntegrationTestBase(SharedLogin.Fixture fixture) : this()
		{
			loginFixture = fixture;
		}

		protected async Task Login()
		{
			if (loginFixture == null)
			{
				throw new Exception($"Login fixture not found. Make sure tests class is decorated with ${nameof(CollectionAttribute)} and proper constructor is called.");
			}
			if (loginFixture.AccessToken == null)
			{
				loginFixture.AccessToken = String.Empty;
				if (TestUtilities.CredentialsFileExists())
				{
					var loginRequestBody = TestUtilities.GetLoginRequestBody();
					var tokens = await Post<Tokens, Login>($"{baseAddress}/auth/login", loginRequestBody);
					loginFixture.AccessToken = tokens.AccessToken;
				}
				else
				{
					throw new Exception("Attempted to login with no credentials setup. Create test credentials file to login within test runs.");
				}
			}
		}

		private async Task<T> Get<T>(string url)
		{
			var response = await client.GetAsync(url);
			return await ReadResponse<T>(response);
		}

		private async Task<T> Post<T, V>(string url, V body)
		{
			var response = await client.PostAsJsonAsync(url, body);
			return await ReadResponse<T>(response);
		}

		private async Task<T> ReadResponse<T>(HttpResponseMessage response)
		{
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var actual = JsonConvert.DeserializeObject<T>(responseContent);
			return actual;
		}
	}
}
