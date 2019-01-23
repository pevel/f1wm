using System.Threading.Tasks;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class EntriesTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetRaceEntries()
		{
			var raceId = 1044;
			var response = await client.GetAsync($"{baseAddress}/Entries?raceId={raceId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<RaceEntriesInformation>(responseContent);
			Assert.NotNull(result);
			Assert.Equal(raceId, result.RaceId);
			Assert.All(result.Entries, entry =>
			{
				Assert.NotEqual(0, entry.Number);
				Assert.NotNull(entry.Car);
				Assert.NotEqual(0, entry.Car.Id);
				Assert.False(string.IsNullOrWhiteSpace(entry.Car.Name));
				Assert.NotNull(entry.Driver);
				Assert.NotEqual((uint)0, entry.Driver.Id);
				Assert.False(string.IsNullOrWhiteSpace(entry.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(entry.Driver.Surname));
				Assert.False(string.IsNullOrWhiteSpace(entry.Driver.Picture));
				Assert.NotEqual(0, entry.Driver.DebutYear);
				Assert.NotNull(entry.Driver.Nationality);
				Assert.False(string.IsNullOrWhiteSpace(entry.Driver.Nationality.Name));
				Assert.False(string.IsNullOrWhiteSpace(entry.Driver.Nationality.FlagIcon));
				Assert.NotNull(entry.Tyres);
				Assert.NotEqual(0, entry.Tyres.Id);
				Assert.False(string.IsNullOrWhiteSpace(entry.Tyres.Name));
				Assert.NotNull(entry.Team);
				Assert.NotEqual(0, entry.Team.Id);
				Assert.False(string.IsNullOrWhiteSpace(entry.Team.Name));
				Assert.False(string.IsNullOrWhiteSpace(entry.Team.Logo));
				Assert.NotNull(entry.Engine);
				Assert.NotEqual(0, entry.Engine.Id);
				Assert.False(string.IsNullOrWhiteSpace(entry.Engine.Name));
			});
		}
	}
}
