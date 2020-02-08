using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
	public abstract class IntegrationTestBase
	{
		protected readonly SharedLogin.Fixture loginFixture;
		protected readonly Fixture generalFixture;
		protected readonly TestServer server;
		protected readonly string baseAddress = "api/";

		private readonly string noFixtureMessage = $"Login fixture not found. Make sure tests class is decorated with {nameof(CollectionAttribute)} and proper constructor is called.";

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

		protected async Task TestIfIsSecured(TestedHttpMethod method, string url, HttpContent content = null)
		{
			Func<string, HttpContent, Task<HttpResponseMessage>> action;
			string parameter;
			switch (method)
			{
				case TestedHttpMethod.POST:
					action = CreateClient(false).PostAsync;
					parameter = "";
					break;
				case TestedHttpMethod.PATCH:
					action = CreateClient(false).PatchAsync;
					parameter = "/123";
					break;
				case TestedHttpMethod.DELETE:
					action = (u, _) => CreateClient(false).DeleteAsync(u);
					parameter = "/321";
					break;
				case TestedHttpMethod.PUT:
					action = CreateClient(false).PutAsJsonAsync;
					parameter = "/456";
					break;
				default:
					throw new NotImplementedException();
			}
			var response = await action($"{url}{parameter}", content ?? new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		protected IntegrationTestBase()
		{
			server = new TestServer(new WebHostBuilder()
				.ConfigureAppConfiguration(config => config.AddUserSecrets<Startup>())
				.UseStartup<Startup>());
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
		}

		protected async Task<T> Get<T>(string url, bool authorize = false)
		{
			var response = await CreateClient(authorize).GetAsync(url);
			return await ReadResponse<T>(response);
		}

		protected async Task<T> Post<T, V>(string url, V body, bool authorize = true)
		{
			var response = await CreateClient(authorize).PostAsJsonAsync(url, body);
			return await ReadResponse<T>(response);
		}

		protected async Task<T> Patch<T, V>(string url, V body, bool authorize = true)
		{
			var response = await CreateClient(authorize).PatchAsync(
				url,
				new ObjectContent(body.GetType(), body, new JsonMediaTypeFormatter(), "application/json")
			);
			return await ReadResponse<T>(response);
		}

		protected async Task Delete(string url, bool authorize = true)
		{
			var response = await CreateClient(authorize).DeleteAsync(url);
			response.EnsureSuccessStatusCode();
		}

		protected HttpClient CreateClient(bool authorize)
		{
			var client = server.CreateClient();
			client.BaseAddress = new Uri(client.BaseAddress + baseAddress);
			if (authorize)
			{
				if (loginFixture == null)
				{
					throw new Exception(noFixtureMessage);
				}
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginFixture.AccessToken);
			}
			return client;
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
