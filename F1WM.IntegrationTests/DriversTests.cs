using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class DriversTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("drivers", "drivers.json")]
		public async Task ShouldGetDrivers(DriversTestData data)
		{
			await TestResponse<Drivers>($"Drivers?letter={data.Letter}", data.Expected);
		}

		[Theory]
		[JsonData("drivers", "driver-details.json")]
		public async Task ShouldGetDriver(DriverDetailsTestData data)
		{
			await TestResponse<DriverDetails>(
				$"Drivers/{data.DriverId}?atYear={data.AtYear}",
				data.Expected,
				data.Why);
		}

		[Theory]
		[JsonData("drivers", "drivers-search.json")]
		public async Task ShouldSearchDrivers(DriversSearchTestData data)
		{
			await TestResponse<SearchResult<DriverSummary>>(
				$"Drivers/Search?filter={data.Filter}",
				data.Expected,
				data.Why);
		}

		public class DriversTestData
		{
			public char Letter { get; set; }
			public Drivers Expected { get; set; }
		}

		public class DriverDetailsTestData
		{
			public int DriverId { get; set; }
			public uint AtYear { get; set; }
			public string Why { get; set; }
			public DriverDetails Expected { get; set; }
		}

		public class DriversSearchTestData
		{
			public string Filter { get; set; }
			public string Why { get; set; }
			public SearchResult<DriverSummary> Expected { get; set; }
		}
	}
}
