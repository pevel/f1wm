using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using F1WM.IntegrationTests.Utilities;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Xunit;

namespace F1WM.IntegrationTests
{
	[Collection(SharedLogin.CollectionName)]
	public class BroadcastsTests : IntegrationTestBase
	{
		private readonly string broadcastsUrl = "broadcasts";
		private readonly string broadcastersUrl = "broadcasts/broadcasters";
		private readonly string typesUrl = "broadcasts/types";
		private readonly string broadcastedRacesUrl = "broadcasts/broadcasted-races";

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
		
		[Theory]
		[JsonData("broadcasts", "broadcasted-races.json")]
		public async Task ShouldGetBroadcastedRaces(BroadcastedRacesTestData data)
		{
			await TestResponse<BroadcastedRace>($"{broadcastedRacesUrl}/{data.RaceId}", data.Expected);
		}

		[Fact]
		public async Task ShouldNotAddBroadcaster()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, broadcastersUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcaster()
		{
			await Login();
			var broadcaster = generalFixture.Create<BroadcasterAddRequest>();
			var addedBroadcaster = await Post<Broadcaster, BroadcasterAddRequest>(broadcastersUrl, broadcaster);
			await Delete($"{broadcastersUrl}/{addedBroadcaster.Id}");
		}

		[Fact]
		public async Task ShouldNotAddBroadcastSessionType()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, typesUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcastSessionType()
		{
			await Login();
			var sessionType = generalFixture.Create<BroadcastSessionTypeAddRequest>();
			var addedSessionType = await Post<BroadcastSessionType, BroadcastSessionTypeAddRequest>(typesUrl, sessionType);
			await Delete($"{typesUrl}/{addedSessionType.Id}");
		}

		[Fact]
		public async Task ShouldNotAddBroadcasts()
		{
			await TestIfIsSecured(TestedHttpMethod.POST, broadcastsUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldAddAndDeleteBroadcasts()
		{
			await Login();
			var raceId = 42;
			var request = CreateBroadcastsAddRequest(raceId, await GetSessionTypes(), await GetBroadcasters());
			var addedBroadcasts = await Post<BroadcastsInformation, BroadcastsAddRequest>(broadcastsUrl, request);
			await Delete($"{broadcastedRacesUrl}/{raceId}");
		}

		[Fact]
		public async Task ShouldNotUpdateBroadcaster()
		{
			await TestIfIsSecured(TestedHttpMethod.PATCH, broadcastersUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldUpdateBroadcaster()
		{
			await Login();
			var broadcaster = generalFixture.Create<BroadcasterAddRequest>();
			var expected = new Broadcaster() { Name = "updated name", Icon = "updated icon", Url = "updated url" };
			var addedBroadcaster = await Post<Broadcaster, BroadcasterAddRequest>(broadcastersUrl, broadcaster);
			var patchDocument = new JsonPatchDocument<Broadcaster>()
				.Replace(b => b.Name, expected.Name)
				.Replace(b => b.Icon, expected.Icon)
				.Replace(b => b.Url, expected.Url);
			var actual = await Patch<Broadcaster, JsonPatchDocument<Broadcaster>>($"{broadcastersUrl}/{addedBroadcaster.Id}", patchDocument);
			await Delete($"{broadcastersUrl}/{addedBroadcaster.Id}");
			actual.Should().BeEquivalentTo(expected, c => c.Excluding(b => b.Id).Excluding(b => b.Broadcasts), "");
		}

		[Fact]
		public async Task ShouldNotUpdateSessionType()
		{
			await TestIfIsSecured(TestedHttpMethod.PATCH, typesUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldUpdateSessionType()
		{
			await Login();
			var sessionType = generalFixture.Create<BroadcastSessionTypeAddRequest>();
			var expected = new BroadcastSessionType() { Name = "updated name " };
			var addedSessionType = await Post<BroadcastSessionType, BroadcastSessionTypeAddRequest>(typesUrl, sessionType);
			var patchDocument = new JsonPatchDocument<BroadcastSessionType>().Replace(b => b.Name, expected.Name);
			var actual = await Patch<BroadcastSessionType, JsonPatchDocument<BroadcastSessionType>>(
				$"{typesUrl}/{addedSessionType.Id}", patchDocument);
			await Delete($"{typesUrl}/{addedSessionType.Id}");
			actual.Should().BeEquivalentTo(expected, c => c.Excluding(b => b.Id), "");
		}

		[Fact]
		public async Task ShouldNotUpdateBroadcastedRace()
		{
			await TestIfIsSecured(TestedHttpMethod.PATCH, broadcastedRacesUrl);
		}

		[RunOnlyIfCredentialsProvided]
		public async Task ShouldUpdateBroadcasts()
		{
			await Login();
			var raceId = 43;
			var newSessionTime = DateTime.Now;
			var broadcasters = await GetBroadcasters();
			var sessionTypes = await GetSessionTypes();
			var addRequest = CreateBroadcastsAddRequest(raceId, sessionTypes, broadcasters);
			var addedBroadcasts = await Post<BroadcastsInformation, BroadcastsAddRequest>(broadcastsUrl, addRequest);
			var newSession = CreateBroadcastedSessionAddRequest(newSessionTime.AddDays(1), broadcasters, sessionTypes.First());
			var patchDocument = new JsonPatchDocument()
				.Replace("/broadcastedSessions/0/start", newSessionTime)
				.Add("/broadcastedSessions/-", newSession);
			var actual = await Patch<BroadcastedRace, JsonPatchDocument>(
				$"{broadcastedRacesUrl}/{raceId}", patchDocument);
			await Delete($"{broadcastedRacesUrl}/{raceId}");
			var actualSession = actual.BroadcastedSessions.Last();
			actual.BroadcastedSessions.ElementAt(0).Start.Should().Be(newSessionTime);
			actualSession.Start.Should().Be(newSession.Start);
			actualSession.TypeName.Should().Be(sessionTypes.Single(t => t.Id == newSession.BroadcastedSessionTypeId).Name);
			Assert.All(actualSession.Broadcasts, broadcast =>
			{
				broadcast.BroadcasterId.Should().BePositive().And.BeOneOf(broadcasters.Select(b => b.Id));
				broadcast.Start.Should().BeOneOf(newSession.Broadcasts.Select(b => b.Start));
			});
		}

		[Fact]
		public async Task ShouldNotDeleteBroadcaster()
		{
			await TestIfIsSecured(TestedHttpMethod.DELETE, broadcastersUrl);
		}

		[Fact]
		public async Task ShouldNotDeleteSessionType()
		{
			await TestIfIsSecured(TestedHttpMethod.DELETE, typesUrl);
		}

		[Fact]
		public async Task ShouldNotDeleteBroadcastedRace()
		{
			await TestIfIsSecured(TestedHttpMethod.DELETE, broadcastedRacesUrl);
		}

		public class NextBroadcastsTestData
		{
			public DateTime After { get; set; }
			public BroadcastsInformation Expected { get; set; }
		}

		public class BroadcastedRacesTestData
		{
			public int RaceId { get; set; }
			public BroadcastedRace Expected { get; set; }
		}

		private Task<IEnumerable<Broadcaster>> GetBroadcasters()
		{
			return Get<IEnumerable<Broadcaster>>(broadcastersUrl);
		}

		private Task<IEnumerable<BroadcastSessionType>> GetSessionTypes()
		{
			return Get<IEnumerable<BroadcastSessionType>>(typesUrl);
		}

		private BroadcastAddRequest CreateBroadcastAddRequest(DateTime time, Broadcaster broadcaster)
		{
			return new BroadcastAddRequest()
			{
				Start = time,
				BroadcasterId = broadcaster.Id
			};
		}

		private BroadcastedSessionAddRequest CreateBroadcastedSessionAddRequest(
			DateTime time,
			IEnumerable<Broadcaster> broadcasters,
			BroadcastSessionType sessionType
		)
		{
			return new BroadcastedSessionAddRequest()
			{
				BroadcastedSessionTypeId = sessionType.Id,
				Start = time,
				Broadcasts = new List<BroadcastAddRequest>()
				{
					CreateBroadcastAddRequest(time.AddDays(1), broadcasters.ToList().ElementAt(0)),
					CreateBroadcastAddRequest(time.AddDays(2), broadcasters.ToList().ElementAt(1)),
					CreateBroadcastAddRequest(time.AddDays(3), broadcasters.ToList().ElementAt(2))
				}
			};
		}

		private BroadcastsAddRequest CreateBroadcastsAddRequest(
			int raceId,
			IEnumerable<BroadcastSessionType> sessionTypes,
			IEnumerable<Broadcaster> broadcasters
		)
		{
			Assert.True(sessionTypes.Count() >= 3, "Cannot add broadcasts when there too few broadcast session types.");
			Assert.True(broadcasters.Count() >= 3, "Cannot add broadcasts when there too few broadcasters.");
			var broadcasts = generalFixture.Create<BroadcastsAddRequest>();
			broadcasts.RaceId = raceId;
			var typesEnumerator = sessionTypes.GetEnumerator();
			broadcasts.Sessions.ToList().ForEach(s => {
				typesEnumerator.MoveNext();
				s.BroadcastedSessionTypeId = typesEnumerator.Current.Id;
				var broadcastersEnumerator = broadcasters.GetEnumerator();
				s.Broadcasts.ToList().ForEach(b =>
				{
					broadcastersEnumerator.MoveNext();
					b.BroadcasterId = broadcastersEnumerator.Current.Id;
				});
			});
			return broadcasts;
		}
	}
}
