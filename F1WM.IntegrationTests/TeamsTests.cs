using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class TeamsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("teams", "team-details.json")]
		public async Task ShouldGetTeam(TeamDetailsTestData data)
		{
			await TestResponse<TeamDetails>($"Teams/{data.TeamId}", data.Expected);
		}

		[Theory]
		[JsonData("teams", "teams.json")]
		public async Task ShouldGetTeams(TeamsTestData data)
		{
			await TestResponse<Teams>($"Teams?letter={data.Letter}", data.Expected);
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
