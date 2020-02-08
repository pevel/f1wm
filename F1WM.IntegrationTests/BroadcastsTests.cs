using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using F1WM.IntegrationTests.Utilities;
using Xunit;

namespace F1WM.IntegrationTests
{
	[Collection(SharedLogin.CollectionName)]
	public class BroadcastsTests : IntegrationTestBase
	{
		private readonly string broadcastsUrl = "broadcasts";
		private readonly string broadcastersUrl = "broadcasts/broadcasters";
		private readonly string typesUrl = "broadcasts/types";

		public BroadcastsTests(SharedLogin.Fixture fixture) : base(fixture)
		{ }

		[Fact]
		public async Task ShouldGetBroadcasters()
		{
			IEnumerable<Broadcaster> result = await GetBroadcasters();
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
			IEnumerable<BroadcastSessionType> result = await GetSessionTypes();
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
				$"{broadcastsUrl}/next?after={WebUtility.UrlEncode(data.After.ToLongDateString())}",
				data.Expected);
		}

		[Fact]
		public async Task ShouldNotAddBroadcaster()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, broadcastersUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcaster()
		{
			var broadcaster = generalFixture.Create<BroadcasterAddRequest>();
			await Login();
			var addedBroadcaster = await Post<Broadcaster, BroadcasterAddRequest>(broadcastersUrl, broadcaster);
			await Delete($"{broadcastersUrl}/{addedBroadcaster.Id}");
		}

		[Fact]
		public async Task ShouldNotUpdateBroadcaster()
		{
			await TestIfIsSecured(TestedHttpMethod.PATCH, broadcastersUrl);
		}

		[Fact]
		public async Task ShouldNotAddBroadcastSessionType()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, typesUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcastSessionType()
		{
			var sessionType = generalFixture.Create<BroadcastSessionTypeAddRequest>();
			await Login();
			var addedSessionType = await Post<BroadcastSessionType, BroadcastSessionTypeAddRequest>(typesUrl, sessionType);
			await Delete($"{typesUrl}/{addedSessionType.Id}");
		}

		[Fact]
		public async Task ShouldNotAddBroadcasts()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, broadcastsUrl);
		}

		public class NextBroadcastsTestData
		{
			public DateTime After { get; set; }
			public BroadcastsInformation Expected { get; set; }
		}

		private Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			return Get<IEnumerable<Broadcaster>>(broadcastersUrl);
		}

		private Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return Get<IEnumerable<BroadcastSessionType>>(typesUrl);
		}
	}
}
