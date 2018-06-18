using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class StandingsTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetConstructorsStandingsTest()
		{
			int count = 5;
			var response = await client.GetAsync($"{baseAddress}/standings/constructors?count={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var standings = JsonConvert.DeserializeObject<ConstructorsStandings>(responseContent);
			Assert.NotNull(standings);
			Assert.True(standings.Positions.ToList().Count <= count);
		}

		[Fact]
		public async Task GetDriversStandingsTest()
		{
			int count = 4;
			var response = await client.GetAsync($"{baseAddress}/standings/drivers?count={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var standings = JsonConvert.DeserializeObject<DriversStandings>(responseContent);
			Assert.NotNull(standings);
			Assert.True(standings.Positions.ToList().Count <= count);
		}
	}
}