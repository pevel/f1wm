using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;

namespace F1WM.UnitTests.Controllers
{
	public class TeamsControllerTests
	{
		private TeamsController controller;
		private Fixture fixture;
		private Mock<ITeamsService> serviceMock;

		public TeamsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<ITeamsService>();
			controller = new TeamsController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnTeamDetails()
		{
			var team = fixture.Create<TeamDetails>();
			var teamId = 44444;
			serviceMock.Setup(s => s.GetTeam(teamId)).ReturnsAsync(team);

			var result = await controller.GetTeam(teamId);

			serviceMock.Verify(s => s.GetTeam(teamId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			team.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldReturn404IfTeamDetailsNotFound()
		{
			var teamId = 55555;
			serviceMock.Setup(s => s.GetTeam(teamId)).ReturnsAsync((TeamDetails)null);

			var result = await controller.GetTeam(teamId);

			serviceMock.Verify(s => s.GetTeam(teamId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnTeams()
		{
			var letter = 'z';
			var teams = fixture.Create<Teams>();
			serviceMock.Setup(s => s.GetTeams(letter)).ReturnsAsync(teams);

			var result = await controller.GetTeams(letter);

			serviceMock.Verify(s => s.GetTeams(letter), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(teams);
		}

		[Fact]
		public async Task ShouldReturn404IfTeamsNotFound()
		{
			var letter = 'x';
			serviceMock.Setup(s => s.GetTeams(letter)).ReturnsAsync((Teams)null);

			var result = await controller.GetTeams(letter);

			serviceMock.Verify(s => s.GetTeams(letter), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn400IfFirstTeamLetterNotProvided()
		{
			var letter = '\0';

			var result = await controller.GetTeams(letter);

			serviceMock.Verify(s => s.GetTeams(letter), Times.Never);
			Assert.IsType<BadRequestResult>(result.Result);
		}
	}
}
