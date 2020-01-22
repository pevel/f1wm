using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class SeasonsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("seasons", "season-rules.json")]
		public async Task ShouldGetSeasonRules(SeasonRulesTestData data)
		{
			await TestResponse<SeasonRules>($"{baseAddress}/Seasons/rules?year={data.Year}", data.Expected);
		}

		[Theory]
		[JsonData("seasons", "season-entries.json")]
		public async Task ShouldGetSeasonEntries(SeasonEntriesTestData data)
		{
			await TestResponse<SeasonEntriesInformation>($"{baseAddress}/Seasons/entries?year={data.Year}", data.Expected);
		}

		public class SeasonRulesTestData
		{
			public uint Year { get; set; }
			public SeasonRules Expected { get; set; }
		}

		public class SeasonEntriesTestData
		{
			public int Year { get; set; }
			public SeasonEntriesInformation Expected { get; set; }
		}
	}
}
