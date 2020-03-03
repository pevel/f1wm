using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class HealthCheckTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetHealthCheck()
		{
			var expectedDatabaseStatus = "OK";

			var check = await Get<HealthCheck>("healthcheck");

			Assert.NotNull(check);
			Assert.Equal(expectedDatabaseStatus, check.DatabaseStatus);
		}
	}
}
