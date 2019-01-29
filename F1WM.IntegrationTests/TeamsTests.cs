using System.Threading.Tasks;
using F1WM.ApiModel;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TeamsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("teams", "team-details.json")]
		public async Task ShouldGetTeam(TeamDetailsTestData data)
		{
			var response = await client.GetAsync($"{baseAddress}/Teams/{data.TeamId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<TeamDetails>(responseContent);

			result.Should().BeEquivalentTo(data.Expected);
		}

		[Theory]
		[JsonData("teams", "teams.json")]
		public async Task ShouldGetTeams(TeamsTestData data)
		{
			var response = await client.GetAsync($"{baseAddress}/Teams?letter={data.Letter}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Teams>(responseContent);

			result.Should().BeEquivalentTo(data.Expected);
		}

		public class TeamDetailsTestData
		{
			public int TeamId { get; set; }
			public TeamDetails Expected { get; set; }
		}

		public class TeamsTestData
		{
			public char Letter { get; set; }
			public Teams Expected { get; set; }
		}
	}
}
