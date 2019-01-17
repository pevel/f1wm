using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class AuthTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldLogin()
		{
			var request = new ObjectContent(
				typeof(Login),
				new Login() { Email = "invalidEmail@nowhere.com", Password = "anyPassword" },
				new JsonMediaTypeFormatter());
			var response = await client.PostAsync($"{baseAddress}/auth/login", request);
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		[Fact]
		public async Task ShouldRegister()
		{
			var request = new ObjectContent(
				typeof(RegisterRequest),
				new RegisterRequest() { Email = "email@nowhere.com", Password = "anyPassword", Key = "wrongKey" },
				new JsonMediaTypeFormatter());
			var response = await client.PostAsync($"{baseAddress}/auth/register", request);
			Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
		}

		[Fact]
		public async Task ShouldRefreshAccessToken()
		{
			var request = new ObjectContent(
				typeof(Tokens),
				new Tokens()
				{
					AccessToken = GetFakeJwt(),
					RefreshToken = Convert.ToBase64String(Encoding.UTF8.GetBytes("refreshToken"))
				},
				new JsonMediaTypeFormatter());
			var response = await client.PostAsync($"{baseAddress}/auth/refresh-token", request);
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		private string GetFakeJwt()
		{
			return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJoZWxsb0B0aGVyZS5jb20iLCJqdGkiOiJkZGE4ZjgxNy0yYTkxLTQ5MjMtYmQzNS1kOGMzNDk4MWVjZTUiLCJleHAiOjE1NDcyOTE3MDQsImlzcyI6ImludGVncmF0aW9uLXRlc3QiLCJhdWQiOiJpbnRlZ3JhdGlvbi10ZXN0In0.zvfvg2Zd5AZiFP0OGaQ_4dSFLJ5uZPPqE0PFckpbwk4";
		}
	}
}
