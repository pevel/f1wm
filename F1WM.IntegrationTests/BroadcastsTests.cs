using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class BroadcastsTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetBroadcastersTest()
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
		public async Task GetBroadcastSessionTypesTest()
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

		[Fact]
		public async Task GetNextBroadcastsTest()
		{
			var nowAtRequestTime = DateTime.Now;
			var response = await client.GetAsync($"{baseAddress}/broadcasts/next");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<BroadcastsInformation>(responseContent);
			Assert.NotNull(result);
			Assert.NotEqual(0, result.RaceId);
			Assert.NotEmpty(result.Sessions);
			Assert.All(result.Sessions, session =>
			{
				Assert.NotEqual(0, session.Id);
				Assert.False(string.IsNullOrWhiteSpace(session.TypeName));
				Assert.True(session.Start > nowAtRequestTime);
			});
			Assert.NotEmpty(result.Broadcasters);
			Assert.All(result.Broadcasters, broadcaster =>
			{
				Assert.NotEqual(0, broadcaster.Id);
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Name));
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Icon));
				Assert.False(string.IsNullOrWhiteSpace(broadcaster.Url));
				Assert.All(broadcaster.Broadcasts, broadcast =>
				{
					Assert.NotEqual(0, broadcast.Id);
					Assert.True(broadcast.Start > nowAtRequestTime);
				});
			});
		}

		[Fact]
		public async Task AddBroadcasterTest()
		{
			var response = await client.PostAsync($"{baseAddress}/broadcasts/broadcasters", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		[Fact]
		public async Task AddBroadcastSessionTypeTest()
		{
			var response = await client.PostAsync($"{baseAddress}/broadcasts/types", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		[Fact]
		public async Task AddBroadcastsTest()
		{
			var response = await client.PostAsync($"{baseAddress}/broadcasts", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}
	}
}
