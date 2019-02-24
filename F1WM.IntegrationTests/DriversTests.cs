using F1WM.ApiModel;
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
			await TestResponse<Drivers>($"{baseAddress}/Drivers?letter={data.Letter}", data.Expected);
		}

		[Theory]
		[JsonData("drivers", "driver-details.json")]
		public async Task ShouldGetDriver(DriverDetailsTestData data)
		{
			await TestResponse<DriverDetails>(
				$"{baseAddress}/Drivers/{data.DriverId}?atYear={data.AtYear}",
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
	}
}
