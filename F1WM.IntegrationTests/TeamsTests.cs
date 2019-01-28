using System.Threading.Tasks;
using F1WM.ApiModel;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TeamsTests : IntegrationTestBase
	{
		public class TeamDetailsTestData
		{
			public int TeamId { get; set; }
			public TeamDetails expected { get; set; }
		}

		[Theory]
		[JsonData("teams", "team-details.json")]
		public async Task ShouldGetTeam(TeamDetailsTestData data)
		{
			var response = await client.GetAsync($"{baseAddress}/Teams/{data.TeamId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<TeamDetails>(responseContent);

			result.Should().BeEquivalentTo(data.expected);
		}
	}
}
