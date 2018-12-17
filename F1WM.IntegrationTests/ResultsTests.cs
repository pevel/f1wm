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
	public class ResultsTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetRaceResultTest()
		{
			var raceId = 1032;
			var response = await client.GetAsync($"{baseAddress}/results/race/{raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var raceResult = JsonConvert.DeserializeObject<RaceResult>(responseContent);
			Assert.NotNull(raceResult);
			Assert.Equal(raceId, raceResult.RaceId);
			Assert.NotNull(raceResult.FastestLap);
			Assert.NotEqual(0, raceResult.FastestLap.LapNumber);
			Assert.NotNull(raceResult.FastestLap.Car);
			Assert.NotEqual(0, raceResult.FastestLap.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(raceResult.FastestLap.Car.Name));
			Assert.NotNull(raceResult.FastestLap.Driver);
			Assert.NotEqual(0, raceResult.FastestLap.Driver.Id);
			Assert.Null(raceResult.FastestLap.Driver.Nationality);
			Assert.False(string.IsNullOrWhiteSpace(raceResult.FastestLap.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(raceResult.FastestLap.Driver.Surname));
			Assert.True(TimeSpan.Zero < raceResult.FastestLap.Time);
			Assert.NotNull(raceResult.Results);
			Assert.NotEmpty(raceResult.Results);
			Assert.All(raceResult.Results, result => {
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual(0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(TimeSpan.Zero < result.Time);
				Assert.True(0 <= result.FinishedLaps);
				Assert.True(0 < result.Number);
				Assert.True(0 <= result.PitStopVisits);
				Assert.False(string.IsNullOrWhiteSpace(result.Tyres));
			});
			raceResult.Results.Aggregate((previous, current) => {
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}
	}
}