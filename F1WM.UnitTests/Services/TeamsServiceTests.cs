using AutoFixture;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class TeamsServiceTests
	{
		private TeamsService service;
		private Fixture fixture;
		private Mock<ITeamsRepository> repositoryMock;

		public TeamsServiceTests()
		{
			fixture = new Fixture();
			repositoryMock = new Mock<ITeamsRepository>();
			service = new TeamsService(repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetTeam()
		{
			var teamId = 12345;
			var team = fixture.Create<TeamDetails>();
			repositoryMock.Setup(r => r.GetTeam(teamId)).ReturnsAsync(team);

			var actual = await service.GetTeam(teamId);

			repositoryMock.Verify(r => r.GetTeam(teamId), Times.Once);
			actual.Should().BeEquivalentTo(team);
		}
	}
}
