using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Utilities;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public abstract class IntegrationTestBase : IDisposable
	{
		protected readonly SharedLogin.Fixture loginFixture;
		protected readonly Fixture generalFixture;
		protected readonly TestServer server;
		protected readonly HttpClient client;
		protected readonly string baseAddress = "api/";

		private readonly string noFixtureMessage = $"Login fixture not found. Make sure tests class is decorated with {nameof(CollectionAttribute)} and proper constructor is called.";

		public void Dispose()
		{
			UnsetAuthorization();
		}

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

		protected async Task TestIfIsSecured(TestedHttpMethod method, string url)
		{
			UnsetAuthorization();
			Func<string, HttpContent, Task<HttpResponseMessage>> action;
			string parameter;
			switch (method)
			{
				case TestedHttpMethod.POST:
					action = client.PostAsync;
					parameter = "";
					break;
				case TestedHttpMethod.PATCH:
					action = client.PatchAsync;
					parameter = "/123";
					break;
				default:
					throw new NotImplementedException();
			}
			var response = await action($"{url}{parameter}", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
			client = server.CreateClient();
			client.BaseAddress = new Uri(client.BaseAddress + baseAddress);
			generalFixture = new Fixture();
		}

		protected IntegrationTestBase(SharedLogin.Fixture fixture) : this()
		{
			loginFixture = fixture;
		}

		protected async Task Login()
		{
			if (loginFixture == null)
			{
				throw new Exception(noFixtureMessage);
			}
			if (loginFixture.AccessToken == null)
			{
				loginFixture.AccessToken = String.Empty;
				if (SharedTestUtilities.CredentialsFileExists())
				{
					var loginRequestBody = SharedTestUtilities.GetLoginRequestBody();
					var tokens = await Post<Tokens, Login>("auth/login", loginRequestBody);
					loginFixture.AccessToken = tokens.AccessToken;
				}
				else
				{
					throw new Exception("Attempted to login with no credentials setup. Create test credentials file to login within test runs.");
				}
			}
			SetAuthorization();
		}

		protected void SetAuthorization()
		{
			if (loginFixture == null)
			{
				throw new Exception(noFixtureMessage);
			}
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginFixture.AccessToken);
		}

		protected void UnsetAuthorization()
		{
			client.DefaultRequestHeaders.Authorization = null;
		}

		protected async Task<T> Get<T>(string url)
		{
			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return await ReadResponse<T>(response);
		}

		protected async Task<T> Post<T, V>(string url, V body)
		{
			var response = await client.PostAsJsonAsync(url, body);
			response.EnsureSuccessStatusCode();
			return await ReadResponse<T>(response);
		}

		protected async Task Delete(string url)
		{
			var response = await client.DeleteAsync(url);
			response.EnsureSuccessStatusCode();
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
