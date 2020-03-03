using System;
using System.Net;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
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
				$"races/next?after={WebUtility.UrlEncode(data.After.ToLongDateString())}",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "last-race.json")]
		public async Task ShouldGetLastRace(LastRaceTestData data)
		{
			await TestResponse<LastRaceSummary>(
				$"races/last?before={WebUtility.UrlEncode(data.Before.ToLongDateString())}",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "race-news.json")]
		public async Task ShouldGetRaceNews(RaceNewsTestData data)
		{
			await TestResponse<RaceNews>(
				$"races/{data.RaceId}/news",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "race-fastest-laps.json")]
		public async Task ShouldGetRaceFastestLaps(RaceFastestLapsTestData data)
		{
			await TestResponse<RaceFastestLaps>(
				$"races/{data.RaceId}/fastest-laps",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "constructors-standings-after-race.json")]
		public async Task ShouldGetConstructorsStandingsAfterRace(ConstructorsStandingsTestData data)
		{
			await TestResponse<ConstructorsStandingsAfterRace>(
				$"races/{data.RaceId}/standings/constructors",
				data.Expected);
		}

		[Theory]
		[JsonData("races", "drivers-standings-after-race.json")]
		public async Task ShouldGetDriversStandingsAfterRace(DriversStandingsTestData data)
		{
			await TestResponse<DriversStandingsAfterRace>(
				$"races/{data.RaceId}/standings/drivers",
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

		public class ConstructorsStandingsTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public ConstructorsStandingsAfterRace Expected { get; set; }
		}

		public class DriversStandingsTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public DriversStandingsAfterRace Expected { get; set; }
		}
	}
}
