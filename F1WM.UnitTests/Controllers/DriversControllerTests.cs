using System.Threading.Tasks;
using AutoFixture;
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
		private Fixture fixture;
		private Mock<IDriversService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public DriversControllerTests()
		{
			serviceMock = new Mock<IDriversService>();
			loggerMock = new Mock<ILoggingService>();
			fixture = new Fixture();
			controller = new DriversController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnDrivers()
		{
			var letter = 'r';
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync(new Drivers());

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfDriversNotFound()
		{
			var letter = 'r';
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync((Drivers)null);

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task ShouldReturn400IfDriverSurnameLetterNotProvided()
		{
			var letter = '\0';
			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Never);
			Assert.IsType<BadRequestResult>(result);
		}

		[Fact]
		public async Task ShouldReturnSingleDriver()
		{
			var driverId = 1;
			var driver = fixture.Create<DriverDetails>();
			serviceMock.Setup(s => s.GetDriver(driverId, null)).ReturnsAsync(driver);

			var result = await controller.GetDriver(driverId, null);

			serviceMock.Verify(s => s.GetDriver(driverId, null), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfDriverNotFound()
		{
			var driverId = 2;
			serviceMock.Setup(s => s.GetDriver(driverId, null)).ReturnsAsync((DriverDetails)null);

			var result = await controller.GetDriver(driverId, null);

			serviceMock.Verify(s => s.GetDriver(driverId, null), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}
