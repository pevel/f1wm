using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class EnginesTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("engines", "engines.json")]
		public async Task ShouldGetEngines(EnginesTestData data)
		{
			await TestResponse<Engines>($"Engines?letter={data.Letter}", data.Expected);
		}

		[Theory]
		[JsonData("engines", "engine-details.json")]
		public async Task ShouldGetEngine(EngineDetailsTestData data)
		{
			await TestResponse<EngineDetails>(
				$"Engines/{data.EngineId}",
				data.Expected,
				data.Why);
		}

		public class EnginesTestData
		{
			public char Letter { get; set; }
			public Engines Expected { get; set; }
		}

		public class EngineDetailsTestData
		{
			public int EngineId { get; set; }
			public string Why { get; set; }
			public EngineDetails Expected { get; set; }
		}
	}
}
