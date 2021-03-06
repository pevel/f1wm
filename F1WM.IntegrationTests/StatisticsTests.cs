using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class StatisticsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("statistics", "driver-statistics.json")]
		public async Task ShouldGetDriverStatistics(DriverStatisticsTestData data)
		{
			await TestResponse<DriverStatistics>(
				$"statistics/drivers/{data.DriverId}?atYear={data.AtYear}",
				data.Expected,
				data.Why);
		}

		[Theory]
		[JsonData("statistics", "team-statistics.json")]
		public async Task ShouldGetTeamStatistics(TeamStatisticsTestData data)
		{
			await TestResponse<TeamStatistics>(
				$"statistics/teams/{data.TeamId}?atYear={data.AtYear}",
				data.Expected,
				data.Why);
		}

		[Theory]
		[JsonData("statistics", "engine-statistics.json")]
		public async Task ShouldGetEngineStatistics(EngineStatisticsTestData data)
		{
			await TestResponse<EngineStatistics>(
				$"statistics/engines/{data.EngineId}?atYear={data.AtYear}",
				data.Expected);
		}

		public class DriverStatisticsTestData
		{
			public int DriverId { get; set; }
			public int AtYear { get; set; }
			public string Why { get; set; }
			public DriverStatistics Expected { get; set; }
		}

		public class TeamStatisticsTestData
		{
			public int TeamId { get; set; }
			public int AtYear { get; set; }
			public string Why { get; set; }
			public TeamStatistics Expected { get; set; }
		}

		public class EngineStatisticsTestData
		{
			public int EngineId { get; set; }
			public int AtYear { get; set; }
			public EngineStatistics Expected { get; set; }
		}
	}
}
