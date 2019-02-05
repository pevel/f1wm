using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class StatisticsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("statistics", "driver-statistics.json")]
		public async Task ShouldGetConstructorsStatistics(DriverStatisticsTestData data)
		{
			await TestResponse<DriverStatistics>(
				$"{baseAddress}/statistics/drivers/{data.DriverId}?atYear={data.AtYear}",
				data.Expected,
				data.Why);
		}

		public class DriverStatisticsTestData
		{
			public int DriverId { get; set; }
			public int AtYear { get; set; }
			public string Why { get; set; }
			public DriverStatistics Expected { get; set; }
		}
	}
}
