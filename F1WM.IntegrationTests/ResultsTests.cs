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
	public class ResultsTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetRaceResult()
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
			Assert.NotEqual((uint)0, raceResult.FastestLap.Driver.Id);
			Assert.Null(raceResult.FastestLap.Driver.Nationality);
			Assert.False(string.IsNullOrWhiteSpace(raceResult.FastestLap.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(raceResult.FastestLap.Driver.Surname));
			Assert.True(TimeSpan.Zero < raceResult.FastestLap.Time);
			Assert.NotNull(raceResult.Results);
			Assert.NotEmpty(raceResult.Results);
			Assert.All(raceResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 <= result.FinishedLaps);
				Assert.True(0 < result.Number);
				Assert.True(0 <= result.PitStopVisits);
				Assert.False(string.IsNullOrWhiteSpace(result.Tyres));
			});
			raceResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetBasicQualifyingResult()
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
			Assert.All(qualifyingResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
				Assert.Null(result.Session2);
				Assert.Null(result.Session3);
			});
			qualifyingResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetCombined12QualifyingResult()
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
			Assert.All(qualifyingResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
			});
			qualifyingResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetCombinedSummed12QualifyingResult()
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
			Assert.All(qualifyingResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
			});
			qualifyingResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetCombined123QualifyingResult()
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
			Assert.All(qualifyingResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 < result.Number);
				Assert.NotNull(result.Session1);
				Assert.True(TimeSpan.Zero < result.Session1.Time);
			});
			qualifyingResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition || current.FinishPosition == null || previous.FinishPosition == null, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetPracticeSessionResult()
		{
			var raceId = 1044;
			var session = "t1";
			var response = await client.GetAsync($"{baseAddress}/results/practice/{raceId}/sessions/{session}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var practiceSessionResult = JsonConvert.DeserializeObject<PracticeSessionResult>(responseContent);
			Assert.NotNull(practiceSessionResult);
			Assert.Equal(raceId, practiceSessionResult.RaceId);
			Assert.Equal(session, practiceSessionResult.Session);
			Assert.NotNull(practiceSessionResult.Results);
			Assert.NotEmpty(practiceSessionResult.Results);
			Assert.All(practiceSessionResult.Results, result =>
			{
				Assert.NotNull(result.Car);
				Assert.NotEqual(0, result.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Car.Name));
				Assert.NotNull(result.Driver);
				Assert.NotEqual((uint)0, result.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(result.Driver.Surname));
				Assert.Null(result.Driver.Nationality);
				Assert.True(0 <= result.FinishedLaps);
				Assert.True(0 < result.Number);
				Assert.False(string.IsNullOrWhiteSpace(result.Tyres));
			});
			practiceSessionResult.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition, "Results are not sorted properly");
				return current;
			});
		}

		[Fact]
		public async Task ShouldGetOtherResult()
		{
			var eventId = 3234;
			var response = await client.GetAsync($"{baseAddress}/results/other/{eventId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<OtherResult>(responseContent);
			Assert.NotNull(result);
			Assert.NotNull(result.Series);
			Assert.NotEqual(0, result.Series.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.Series.Name));
			Assert.Equal(eventId, result.EventId);
			Assert.False(string.IsNullOrWhiteSpace(result.EventName));
			Assert.NotNull(result.Results);
			Assert.NotEmpty(result.Results);
			Assert.NotNull(result.AdditionalPoints);
			Assert.False(string.IsNullOrWhiteSpace(result.FastestLapResult.Car.Name));
			Assert.False(string.IsNullOrWhiteSpace(result.FastestLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(result.FastestLapResult.Driver.Surname));
			Assert.True(0 < result.FastestLapResult.LapNumber);
			Assert.True(TimeSpan.Zero < result.FastestLapResult.Time);
			Assert.False(string.IsNullOrWhiteSpace(result.PolePositionLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(result.PolePositionLapResult.Driver.Surname));
			Assert.True(TimeSpan.Zero < result.PolePositionLapResult.Time);
			Assert.All(result.Results, r =>
			{
				Assert.NotNull(r.Car);
				Assert.NotEqual(0, r.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(r.Car.Name));
				Assert.False(string.IsNullOrWhiteSpace(r.TeamName));
				Assert.NotNull(r.Driver);
				Assert.NotEqual((uint)0, r.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(r.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(r.Driver.Surname));
				Assert.NotNull(r.Driver.Nationality);
				Assert.True(0 <= r.FinishedLaps);
				Assert.False(string.IsNullOrWhiteSpace(r.Number));
			});
			result.Results.Aggregate((previous, current) =>
			{
				Assert.True(previous.FinishPosition < current.FinishPosition, "Results are not sorted properly");
				return current;
			});
		}
	}
}
