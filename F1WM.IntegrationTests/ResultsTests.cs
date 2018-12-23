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

		[Fact]
		public async Task GetBasicQualifyingResultTest()
		{
			var raceId = 1;
			var response = await client.GetAsync($"{baseAddress}/results/qualifying/{raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var qualifyingResult = JsonConvert.DeserializeObject<QualifyingResult>(responseContent);
			Assert.NotNull(qualifyingResult);
			Assert.Equal(raceId, qualifyingResult.RaceId);
			Assert.Equal(QualifyingResultFormat.Basic, qualifyingResult.Format);
			Assert.NotNull(qualifyingResult.Results);
			Assert.NotEmpty(qualifyingResult.Results);
			Assert.All(qualifyingResult.Results, result => {
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual(0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
				Assert.Null(result.Session2);
				Assert.Null(result.Session3);
			});
			qualifyingResult.Results.Aggregate((previous, current) => {
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task GetCombined12QualifyingResultTest()
		{
			var raceId = 700;
			var response = await client.GetAsync($"{baseAddress}/results/qualifying/{raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var qualifyingResult = JsonConvert.DeserializeObject<QualifyingResult>(responseContent);
			Assert.NotNull(qualifyingResult);
			Assert.Equal(raceId, qualifyingResult.RaceId);
			Assert.Equal(QualifyingResultFormat.Combined12, qualifyingResult.Format);
			Assert.NotNull(qualifyingResult.Results);
			Assert.NotEmpty(qualifyingResult.Results);
			Assert.All(qualifyingResult.Results, result => {
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual(0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
			});
			qualifyingResult.Results.Aggregate((previous, current) => {
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task GetCombinedSummed12QualifyingResultTest()
		{
			var raceId = 733;
			var response = await client.GetAsync($"{baseAddress}/results/qualifying/{raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var qualifyingResult = JsonConvert.DeserializeObject<QualifyingResult>(responseContent);
			Assert.NotNull(qualifyingResult);
			Assert.Equal(raceId, qualifyingResult.RaceId);
			Assert.Equal(QualifyingResultFormat.CombinedSummed12, qualifyingResult.Format);
			Assert.NotNull(qualifyingResult.Results);
			Assert.NotEmpty(qualifyingResult.Results);
			Assert.All(qualifyingResult.Results, result => {
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual(0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
			});
			qualifyingResult.Results.Aggregate((previous, current) => {
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task GetCombined123QualifyingResultTest()
		{
			var raceId = 1044;
			var response = await client.GetAsync($"{baseAddress}/results/qualifying/{raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var qualifyingResult = JsonConvert.DeserializeObject<QualifyingResult>(responseContent);
			Assert.NotNull(qualifyingResult);
			Assert.Equal(raceId, qualifyingResult.RaceId);
			Assert.Equal(QualifyingResultFormat.Combined123, qualifyingResult.Format);
			Assert.NotNull(qualifyingResult.Results);
			Assert.NotEmpty(qualifyingResult.Results);
			Assert.All(qualifyingResult.Results, result => {
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual(0, result.Driver.Id);
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
			});
			qualifyingResult.Results.Aggregate((previous, current) => {
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}
	}
}