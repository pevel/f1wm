using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
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

		[Theory]
		[JsonData("tracks", "track-records.json")]
		public async Task ShouldGetTracks(TracksSummaryTestData data)
		{
			await TestResponse<TrackSummary>(
				$"{baseAddress}/tracks?countPerPage={data.CountPerPage}&page={data.Page}",
				data.Expected);
		}

		[Theory]
		[JsonData("tracks", "track-records.json")]
		public async Task ShouldGetTracksByStatusId(TracksSummaryTestData data)
		{
			var statusId = 2;

			await TestResponse<TrackSummary>(
				$"{baseAddress}/tracks?statusId={statusId}&countPerPage={data.CountPerPage}&page={data.Page}",
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
			public TrackSummary Expected { get; set; }
		}
	}
}
