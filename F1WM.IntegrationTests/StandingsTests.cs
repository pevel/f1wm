using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class StandingsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("standings", "constructors-standings.json")]
		public async Task ShouldGetConstructorsStandings(ConstructorsStandingsTestData data)
		{
			await TestResponse<ConstructorsStandings>(
				$"standings/constructors?seasonId={data.SeasonId}&count={data.Count}",
				data.Expected);
		}

		[Theory]
		[JsonData("standings", "drivers-standings.json")]
		public async Task ShouldGetDriversStandings(DriversStandingsTestData data)
		{
			await TestResponse<DriversStandings>(
				$"standings/drivers?seasonId={data.SeasonId}&count={data.Count}",
				data.Expected);
		}

		public class ConstructorsStandingsTestData
		{
			public int SeasonId { get; set; }
			public int Count { get; set; }
			public ConstructorsStandings Expected { get; set; }
		}

		public class DriversStandingsTestData
		{
			public int SeasonId { get; set; }
			public int Count { get; set; }
			public DriversStandings Expected { get; set; }
		}
	}
}
