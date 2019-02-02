using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class GridsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("grids", "grid.json")]
		public async Task ShouldGetGrid(GridTestData data)
		{
			await TestResponse<GridInformation>($"{baseAddress}/Grids?raceId={data.RaceId}", data.Expected, data.Why);
		}

		public class GridTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public GridInformation Expected { get; set; }
		}
	}
}
