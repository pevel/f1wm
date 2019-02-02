using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class EntriesTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("entries", "race-entries.json")]
		public async Task ShouldGetRaceEntries(RaceEntriesTestData data)
		{
			await TestResponse<RaceEntriesInformation>($"{baseAddress}/Entries?raceId={data.RaceId}", data.Expected, data.Why);
		}

		public class RaceEntriesTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public RaceEntriesInformation Expected { get; set; }
		}
	}
}
