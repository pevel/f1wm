using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class RacesControllerTests
	{
		private RacesController controller;
		private Mock<IRacesService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public RacesControllerTests()
		{
			serviceMock = new Mock<IRacesService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new RacesController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextRace()
		{
			serviceMock.Setup(s => s.GetNextRace()).ReturnsAsync(new NextRaceSummary());

			var result = await controller.GetNextRace();

			serviceMock.Verify(s => s.GetNextRace(), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			serviceMock.Setup(s => s.GetNextRace()).ReturnsAsync((NextRaceSummary)null);

			var result = await controller.GetNextRace();

			serviceMock.Verify(s => s.GetNextRace(), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task ShouldReturnLastRace()
		{
			serviceMock.Setup(s => s.GetLastRace()).ReturnsAsync(new LastRaceSummary());

			var result = await controller.GetLastRace();

			serviceMock.Verify(s => s.GetLastRace(), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfLastRaceNotFound()
		{
			serviceMock.Setup(s => s.GetLastRace()).ReturnsAsync((LastRaceSummary)null);

			var result = await controller.GetLastRace();

			serviceMock.Verify(s => s.GetLastRace(), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}