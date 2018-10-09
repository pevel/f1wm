using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.Controllers;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;
using System;

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
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Track.Name));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Track.TrackIcon));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.Name));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.TranslatedName));
			Assert.NotNull(nextRace.LastFastestLapResult);
			Assert.NotEqual(nextRace.LastFastestLapResult.Time.TotalMilliseconds, 0);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastFastestLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastFastestLapResult.Driver.Surname));
			Assert.NotNull(nextRace.LastPolePositionLapResult);
			Assert.NotEqual(nextRace.LastPolePositionLapResult.Time.TotalMilliseconds, 0);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastPolePositionLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastPolePositionLapResult.Driver.Surname));
			Assert.NotNull(nextRace.LastWinnerRaceResult);
			Assert.NotEqual(nextRace.LastWinnerRaceResult.Time.TotalMilliseconds, 0);
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastWinnerRaceResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(nextRace.LastWinnerRaceResult.Driver.Surname));
			Assert.True(nextRace.Date > nowAtRequestTime);
		}
	}
}