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

		[Fact]
		public async Task ShouldGetSeasonRulesWithNoYearSpecified()
		{
			var response = await client.GetAsync($"{baseAddress}/Seasons/rules");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var seasonRules = JsonConvert.DeserializeObject<SeasonRules>(responseContent);
			Assert.False(string.IsNullOrWhiteSpace(seasonRules.CarWeight));
			Assert.False(string.IsNullOrWhiteSpace(seasonRules.EngineRules));
			Assert.False(string.IsNullOrWhiteSpace(seasonRules.PointsSystem));
			Assert.False(string.IsNullOrWhiteSpace(seasonRules.QualifyingRules));
		}

		public class SeasonRulesTestData
		{
			public uint Year { get; set; }
			public SeasonRules Expected { get; set; }
		}
	}
}
