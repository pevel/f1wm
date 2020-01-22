using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	[Collection(SharedLogin.CollectionName)]
	public class BroadcastsTests : IntegrationTestBase
	{
		public BroadcastsTests(SharedLogin.Fixture fixture) : base(fixture)
		{ }

		[Fact]
		public async Task ShouldGetBroadcasters()
		{
			var response = await client.GetAsync($"{baseAddress}/broadcasts/broadcasters");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<IEnumerable<Broadcaster>>(responseContent);
			Assert.NotNull(result);
			Assert.All(result, broadcaster =>
			{
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Icon));
				Assert.NotEqual(0, broadcaster.Id);
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Name));
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Url));
			});
		}

		[Fact]
		public async Task ShouldGetBroadcastSessionTypes()
		{
			var response = await client.GetAsync($"{baseAddress}/broadcasts/types");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<IEnumerable<BroadcastSessionType>>(responseContent);
			Assert.NotNull(result);
			Assert.All(result, type =>
			{
				Assert.False(string.IsNullOrWhiteSpace(type.Name));
				Assert.NotEqual(0, type.Id);
			});
		}

		[Theory]
		[JsonData("broadcasts", "next-broadcasts.json")]
		public async Task ShouldGetNextBroadcasts(NextBroadcastsTestData data)
		{
			await TestResponse<BroadcastsInformation>(
				$"{baseAddress}/broadcasts/next?after={WebUtility.UrlEncode(data.After.ToLongDateString())}",
				data.Expected);
		}

		[Fact]
		public async Task ShouldNotAddBroadcaster()
		{
			UnsetAuthorization();
			var response = await client.PostAsync($"{baseAddress}/broadcasts/broadcasters", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcaster()
		{
			await Login();
			SetAuthorization();
			var broadcaster = generalFixture.Build<Broadcaster>()
				.Without(b => b.Broadcasts)
				.Without(b => b.Id)
				.Create();
			var addResponse = await client.PostAsJsonAsync($"{baseAddress}/broadcasts/broadcasters", broadcaster);
			addResponse.EnsureSuccessStatusCode();
			var responseContent = await addResponse.Content.ReadAsStringAsync();
			var addedBroadcaster = JsonConvert.DeserializeObject<Broadcaster>(responseContent);
			var deleteResponse = await client.DeleteAsync($"{baseAddress}/broadcasts/broadcasters/{addedBroadcaster.Id}");
			deleteResponse.EnsureSuccessStatusCode();
		}

		[Fact]
		public async Task ShouldNotAddBroadcastSessionType()
		{
			UnsetAuthorization();
			var response = await client.PostAsync($"{baseAddress}/broadcasts/types", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		[Fact]
		public async Task ShouldNotAddBroadcasts()
		{
			UnsetAuthorization();
			var response = await client.PostAsync($"{baseAddress}/broadcasts", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		public class NextBroadcastsTestData
		{
			public DateTime After { get; set; }
			public BroadcastsInformation Expected { get; set; }
		}
	}
}
