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
		public async Task GetNextRaceTest()
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
	}
}