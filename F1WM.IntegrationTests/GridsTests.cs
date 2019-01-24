using System;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class GridsTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetRaceEntries()
		{
			var raceId = 1044;
			var response = await client.GetAsync($"{baseAddress}/Grids?raceId={raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<GridInformation>(responseContent);
			Assert.NotNull(result);
			Assert.Equal(raceId, result.RaceId);
			Assert.All(result.GridPositions, position =>
			{
				Assert.True(TimeSpan.Zero < position.Time);
				Assert.NotEqual(0, position.StartPosition);
				Assert.NotNull(position.Car);
				Assert.NotEqual(0, position.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(position.Car.Name));
				Assert.NotNull(position.Driver);
				Assert.NotEqual((uint)0, position.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(position.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(position.Driver.Surname));
				Assert.False(string.IsNullOrWhiteSpace(position.Driver.Picture));
				Assert.Null(position.Driver.Nationality);
			});
			result.GridPositions.Aggregate((previous, current) =>
			{
				Assert.True(previous.StartPosition < current.StartPosition, "Grid positions are not sorted properly");
				return current;
			});
		}
	}
}
