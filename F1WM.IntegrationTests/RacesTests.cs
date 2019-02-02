using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class RacesTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetNextRace()
		{
			var nowAtRequestTime = DateTime.Now;
			var response = await client.GetAsync($"{baseAddress}/races/next");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var nextRace = JsonConvert.DeserializeObject<NextRaceSummary>(responseContent);
			Assert.NotNull(nextRace);
			Assert.NotNull(nextRace.Track);
			Assert.NotEqual(0, nextRace.Id);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Track.Name));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Track.TrackIcon));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Name));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.TranslatedName));
			Assert.NotNull(nextRace.LastFastestLapResult);
			Assert.NotEqual(0, nextRace.LastFastestLapResult.Time.TotalMilliseconds);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastFastestLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastFastestLapResult.Driver.Surname));
			Assert.NotNull(nextRace.LastPolePositionLapResult);
			Assert.NotEqual(0, nextRace.LastPolePositionLapResult.Time.TotalMilliseconds);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastPolePositionLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastPolePositionLapResult.Driver.Surname));
			Assert.NotNull(nextRace.LastWinnerRaceResult);
			Assert.NotEqual(0, nextRace.LastWinnerRaceResult.Time.TotalMilliseconds);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastWinnerRaceResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastWinnerRaceResult.Driver.Surname));
			Assert.True(nextRace.Date > nowAtRequestTime);
		}

		[Fact]
		public async Task ShouldGetLastRace()
		{
			var nowAtRequestTime = DateTime.Now;
			var response = await client.GetAsync($"{baseAddress}/races/last");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var lastRace = JsonConvert.DeserializeObject<LastRaceSummary>(responseContent);
			Assert.NotNull(lastRace);
			Assert.NotNull(lastRace.Track);
			Assert.NotEqual(0, lastRace.Id);
			Assert.False(string.IsNullOrWhiteSpace(lastRace.Track.Name));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.Track.TrackIcon));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.Name));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.TranslatedName));
			Assert.NotNull(lastRace.FastestLapResult);
			Assert.NotEqual(0, lastRace.FastestLapResult.Time.TotalMilliseconds);
			Assert.NotEqual(0, lastRace.FastestLapResult.LapNumber);
			Assert.NotNull(lastRace.FastestLapResult.Car);
			Assert.NotEqual(0, lastRace.FastestLapResult.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(lastRace.FastestLapResult.Car.Name));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.FastestLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.FastestLapResult.Driver.Surname));
			Assert.NotNull(lastRace.PolePositionLapResult);
			Assert.NotEqual(0, lastRace.PolePositionLapResult.Time.TotalMilliseconds);
			Assert.False(string.IsNullOrWhiteSpace(lastRace.PolePositionLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(lastRace.PolePositionLapResult.Driver.Surname));
			Assert.True(lastRace.Date < nowAtRequestTime);
			Assert.NotNull(lastRace.ShortResults);
			Assert.Equal(10, lastRace.ShortResults.Count());
			Assert.All(lastRace.ShortResults, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 <= result.FinishedLaps);
				Assert.True(0 < result.Number);
				Assert.True(0 <= result.PitStopVisits);
				Assert.False(string.IsNullOrWhiteSpace(result.Tyres));
			});
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
	}
}
