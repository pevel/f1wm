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
	public class DriversControllerTests
	{
		private DriversController controller;
		private Mock<IDriversService> serviceMock;
		private Mock<ILoggingService> loggerMock;
		private readonly string letter = "r";

		public DriversControllerTests()
		{
			serviceMock = new Mock<IDriversService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new DriversController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnDrivers()
		{
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync(new Drivers());

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfSeasonRulesNotFound()
		{
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync((Drivers)null);

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}
