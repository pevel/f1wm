using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TracksTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("tracks", "track-details.json")]
		public async Task ShouldGetTrack(TrackDetailsTestData data)
		{
			await TestResponse<TrackDetails>(
				$"tracks/{data.TrackId}?atYear={data.AtYear}",
				data.Expected);
		}

		[Theory]
		[JsonData("tracks", "track-records.json")]
		public async Task ShouldGetTrackRecords(TrackRecordsTestData data)
		{
			await TestResponse<TrackRecordsInformation>(
				$"tracks/{data.TrackId}/versions/{data.TrackVersion}/records?beforeYear={data.BeforeYear}",
				data.Expected);
		}

		[Theory]
		[JsonData("tracks", "all-tracks-summary.json")]
		public async Task ShouldGetTracks(TracksSummaryTestData data)
		{
			await TestResponse<PagedResult<Track>>(
				$"tracks?countPerPage={data.CountPerPage}&page={data.Page}",
				data.Expected);
		}

		[Theory]
		[JsonData("tracks", "track-summary.json")]
		public async Task ShouldGetTracksByStatus(TracksSummaryTestData data)
		{
			await TestResponse<PagedResult<Track>>(
				$"tracks?status={data.Status}&countPerPage={data.CountPerPage}&page={data.Page}",
				data.Expected);
		}

		[Theory]
		[JsonData("tracks", "track-short-results-by-years.json")]
		public async Task ShouldGetTrackShortResultsByYears(TrackShortResultsByYearsTestData data)
		{
			await TestResponse<TrackShortResultsByYears>(
				$"tracks/{data.TrackId}/short-results?untilYear={data.UntilYear}",
				data.Expected);
		}

		public class TrackRecordsTestData
		{
			public int TrackId { get; set; }
			public int TrackVersion { get; set; }
			public uint BeforeYear { get; set; }
			public TrackRecordsInformation Expected { get; set; }
		}

		public class TracksSummaryTestData
		{
			public uint CountPerPage { get; set; }
			public uint Page { get; set; }
			public uint Status { get; set; }
			public PagedResult<Track> Expected { get; set; }
		}

		public class TrackDetailsTestData
		{
			public int TrackId { get; set; }
			public int AtYear { get; set; }
			public TrackDetails Expected { get; set; }
		}

		public class TrackShortResultsByYearsTestData
		{
			public int TrackId { get; set; }
			public int UntilYear { get; set; }
			public TrackShortResultsByYears Expected { get; set; }
		}
	}
}
