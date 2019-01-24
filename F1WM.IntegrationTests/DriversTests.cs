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
	}
}
