using System.Threading.Tasks;
using AutoFixture;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using F1WM.ApiModel;

namespace F1WM.UnitTests.Controllers
{
	public class EntriesControllerTests
	{
		private EntriesController controller;
		private Fixture fixture;
		private Mock<IEntriesService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public EntriesControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IEntriesService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new EntriesController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnRaceEntries()
		{
			var raceId = 9000;
			var Entries = fixture.Create<RaceEntriesInformation>();
			serviceMock.Setup(s => s.GetRaceEntries(raceId)).ReturnsAsync(Entries);

			var result = await controller.GetRaceEntries(raceId);

			serviceMock.Verify(s => s.GetRaceEntries(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			Entries.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceEntriesNotFound()
		{
			var raceId = 9001;
			serviceMock.Setup(s => s.GetRaceEntries(raceId)).ReturnsAsync((RaceEntriesInformation)null);

			var result = await controller.GetRaceEntries(raceId);

			serviceMock.Verify(s => s.GetRaceEntries(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
