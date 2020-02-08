using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class HealthCheckTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetHealthCheck()
		{
			var expectedDatabaseStatus = "OK";

			var response = await client.GetAsync($"healthcheck");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var check = JsonConvert.DeserializeObject<HealthCheck>(responseContent);
			Assert.NotNull(check);
			Assert.Equal(expectedDatabaseStatus, check.DatabaseStatus);
		}
	}
}
