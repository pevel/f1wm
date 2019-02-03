using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TracksTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("tracks", "track-records.json")]
		public async Task ShouldGetTrackRecords(TrackRecordsTestData data)
		{
			await TestResponse<TrackRecordsInformation>(
				$"{baseAddress}/tracks/{data.TrackId}/versions/{data.TrackVersion}/records?beforeYear={data.BeforeYear}",
				data.Expected);
		}

		public class TrackRecordsTestData
		{
			public int TrackId { get; set; }
			public int TrackVersion { get; set; }
			public uint BeforeYear { get; set; }
			public TrackRecordsInformation Expected { get; set; }
		}

		[Fact]
		public async Task ShouldGetTracks()
		{
			var count = 5;

			var response = await client.GetAsync($"{baseAddress}/tracks?countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<PagedResult<TrackSummary>>(responseContent);
			Assert.NotNull(result.Result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			Assert.NotNull(result.Result);
			Assert.Equal(count, result.Result.Count());
			Assert.All(result.Result, track =>
			{
				Assert.NotEqual((uint)0, track.Id);
				Assert.NotNull(track.City);
				Assert.NotNull(track.Country);
				Assert.NotNull(track.ShortName);
				Assert.True(track.StatusId < 3);
				Assert.False(string.IsNullOrWhiteSpace(track.TrackIcon));
			});
		}

		[Fact]
		public async Task ShouldGetTracksByStatusId()
		{
			var statusId = 2;
			var count = 7;

			var response = await client.GetAsync($"{baseAddress}/tracks?statusId={statusId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<PagedResult<TrackSummary>>(responseContent);
			Assert.NotNull(result.Result);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(count, result.PageSize);
			Assert.Equal(result.Result.Count(), count);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			Assert.NotNull(result.Result);
			Assert.Equal(count, result.Result.Count());
			Assert.All(result.Result, track =>
			{
				Assert.NotEqual((uint)0, track.Id);
				Assert.NotNull(track.City);
				Assert.NotNull(track.Country);
				Assert.NotNull(track.ShortName);
				Assert.True(track.StatusId < 3);
				Assert.False(string.IsNullOrWhiteSpace(track.TrackIcon));
			});
		}
	}
}
