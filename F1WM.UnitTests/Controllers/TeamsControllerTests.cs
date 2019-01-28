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
		private Mock<ILoggingService> loggerMock;

		public TeamsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<ITeamsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new TeamsController(serviceMock.Object, loggerMock.Object);
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
	}
}
