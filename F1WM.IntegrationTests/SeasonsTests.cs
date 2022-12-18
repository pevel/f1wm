using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class SeasonsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("seasons", "season-rules.json")]
		public async Task ShouldGetSeasonRules(SeasonRulesTestData data)
		{
			await TestResponse<SeasonRules>($"Seasons/rules?year={data.Year}", data.Expected);
		}

		[Theory]
		[JsonData("seasons", "season-entries.json")]
		public async Task ShouldGetSeasonEntries(SeasonEntriesTestData data)
		{
			await TestResponse<SeasonEntriesInformation>($"Seasons/entries?year={data.Year}", data.Expected);
		}

		public class SeasonRulesTestData
		{
			public int Year { get; set; }
			public SeasonRules Expected { get; set; }
		}

		public class SeasonEntriesTestData
		{
			public int Year { get; set; }
			public SeasonEntriesInformation Expected { get; set; }
		}
	}
}
