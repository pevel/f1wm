using System.Threading.Tasks;
using F1WM.ApiModel;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class EnginesTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("engines", "engines.json")]
		public async Task ShouldGetEngines(EnginesTestData data)
		{
			var response = await client.GetAsync($"{baseAddress}/Engines?letter={data.Letter}");
			response.EnsureSuccessStatusCode();
			
			var responseContent = await response.Content.ReadAsStringAsync();
			var engines = JsonConvert.DeserializeObject<Engines>(responseContent);
			
			engines.Should().BeEquivalentTo(data.Expected);
		}

		[Theory]
		[JsonData("engines", "engine-details.json")]
		public async Task ShouldGetEngine(EngineDetailsTestData data)
		{
			var response = await client.GetAsync($"{baseAddress}/Engines/{data.EngineId}");
			response.EnsureSuccessStatusCode();
			
			var responseContent = await response.Content.ReadAsStringAsync();
			var engines = JsonConvert.DeserializeObject<EngineDetails>(responseContent);
			
			engines.Should().BeEquivalentTo(data.Expected);
		}

		public class EnginesTestData
		{
			public char Letter { get; set; }
			public Engines Expected { get; set; }
		}

		public class EngineDetailsTestData
		{
			public int EngineId { get; set; }
			public EngineDetails Expected { get; set; }
		}
	}
}
