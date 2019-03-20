using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class RacesTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("races", "next-race.json")]
		public async Task ShouldGetNextRace(NextRaceTestData data)
		{
			await TestResponse<NextRaceSummary>(
				$"{baseAddress}/races/next?after={WebUtility.UrlEncode(data.After.ToLongDateString())}",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "last-race.json")]
		public async Task ShouldGetLastRace(LastRaceTestData data)
		{
			await TestResponse<LastRaceSummary>(
				$"{baseAddress}/races/last?before={WebUtility.UrlEncode(data.Before.ToLongDateString())}",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "race-news.json")]
		public async Task ShouldGetRaceNews(RaceNewsTestData data)
		{
			await TestResponse<RaceNews>(
				$"{baseAddress}/races/{data.RaceId}/news",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "race-fastest-laps.json")]
		public async Task ShouldGetRaceFastestLaps(RaceFastestLapsTestData data)
		{
			await TestResponse<RaceFastestLaps>(
				$"{baseAddress}/races/{data.RaceId}/fastest-laps",
				data.Expected);
		}

		public class RaceFastestLapsTestData
		{
			public int RaceId { get; set; }
			public RaceFastestLaps Expected { get; set; }
		}

		public class RaceNewsTestData
		{
			public int RaceId { get; set; }
			public RaceNews Expected { get; set; }
		}

		public class NextRaceTestData
		{
			public DateTime After { get; set; }
			public NextRaceSummary Expected { get; set; }
		}

		public class LastRaceTestData
		{
			public DateTime Before { get; set; }
			public LastRaceSummary Expected { get; set; }
		}
	}
}
