using System.Threading.Tasks;
using F1WM.ApiModel.Engines;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class EnginesTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetEngines()
		{
			var response = await client.GetAsync($"{baseAddress}/Engines?letter=a");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var engines = JsonConvert.DeserializeObject<Engines>(responseContent);
			Assert.All(engines.EnginesList, engine =>
			{
				Assert.NotEqual(0, (int)engine.Id);
				Assert.False(string.IsNullOrWhiteSpace(engine.Name));
			});
		}
	}
}
