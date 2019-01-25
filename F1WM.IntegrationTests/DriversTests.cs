using F1WM.ApiModel;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class DriversTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetDrivers()
		{
			var response = await client.GetAsync($"{baseAddress}/Drivers?letter=r");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var drivers = JsonConvert.DeserializeObject<Drivers>(responseContent);
			Assert.All(drivers.DriversList, driver =>
			{
				Assert.NotEqual(0, (int)driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(driver.Surname));
				Assert.False(string.IsNullOrWhiteSpace(driver.Nationality.FlagIcon));
				Assert.False(string.IsNullOrWhiteSpace(driver.Nationality.Name));
			});
		}

		[Fact]
		public async Task ShouldGetDriver()
		{
			var driverId = 806;
			var response = await client.GetAsync($"{baseAddress}/Drivers/{driverId}");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var driver = JsonConvert.DeserializeObject<DriverDetails>(responseContent);
			Assert.NotEqual((uint)0, driver.Id);
			Assert.NotNull(driver.Nationality);
			Assert.False(string.IsNullOrWhiteSpace(driver.Nationality.FlagIcon));
			Assert.False(string.IsNullOrWhiteSpace(driver.Nationality.Name));
			Assert.NotEqual(0, driver.Number);
			Assert.False(string.IsNullOrWhiteSpace(driver.Picture));
			Assert.False(string.IsNullOrWhiteSpace(driver.Surname));
			Assert.False(string.IsNullOrWhiteSpace(driver.FirstName));
			Assert.NotNull(driver.Team);
			Assert.NotEqual(0, driver.Team.Id);
			Assert.False(string.IsNullOrWhiteSpace(driver.Team.Logo));
			Assert.False(string.IsNullOrWhiteSpace(driver.Team.Name));
			Assert.NotNull(driver.Car);
			Assert.NotEqual(0, driver.Car.Id);
			Assert.False(string.IsNullOrWhiteSpace(driver.Car.Name));
		}
	}
}
