using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TracksTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetTrackRecords()
		{
			var trackId = 57;
			var trackVersion = 1;
			var year = 2010;
			var response = await client.GetAsync($"{baseAddress}/tracks/{trackId}/versions/{trackVersion}/records?beforeYear={year}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<TrackRecordsInformation>(responseContent);
			Assert.NotNull(result);
			Assert.Equal(trackId, result.TrackId);
			Assert.Equal(trackVersion, result.TrackVersion);
			Assert.Equal(year, result.BeforeYear);
			Assert.NotNull(result.BestAverageSpeedResult);
			Assert.True(0 < result.BestAverageSpeedResult.AverageSpeed);
			Assert.False(string.IsNullOrWhiteSpace(result.BestAverageSpeedResult.Car.Name));
			Assert.NotEqual(0, result.BestAverageSpeedResult.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.BestAverageSpeedResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(result.BestAverageSpeedResult.Driver.Surname));
			Assert.NotEqual(0, result.BestAverageSpeedResult.Driver.Id);
			Assert.Null(result.BestAverageSpeedResult.Driver.Nationality);
			Assert.NotNull(result.FastestQualifyingLapResult);
			Assert.NotEqual(0, result.FastestQualifyingLapResult.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.FastestQualifyingLapResult.Car.Name));	
			Assert.NotEqual(0, result.FastestQualifyingLapResult.Driver.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.FastestQualifyingLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(result.FastestQualifyingLapResult.Driver.Surname));
			Assert.Null(result.FastestQualifyingLapResult.Driver.Nationality);
			Assert.NotNull(result.FastestRaceLapResult);
			Assert.NotEqual(0, result.FastestRaceLapResult.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.FastestRaceLapResult.Car.Name));	
			Assert.NotEqual(0, result.FastestRaceLapResult.Driver.Id);
			Assert.False(string.IsNullOrWhiteSpace(result.FastestRaceLapResult.Driver.FirstName));
			Assert.False(string.IsNullOrWhiteSpace(result.FastestRaceLapResult.Driver.Surname));
			Assert.Null(result.FastestRaceLapResult.Driver.Nationality);
		}
	}
}
