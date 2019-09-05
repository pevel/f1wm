using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using FluentAssertions;
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

		public DriversControllerTests()
		{
			serviceMock = new Mock<IDriversService>();
			fixture = new Fixture();
			controller = new DriversController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnDrivers()
		{
			var letter = 'r';
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync(new Drivers());

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfDriversNotFound()
		{
			var letter = 'r';
			serviceMock.Setup(s => s.GetDrivers(letter)).ReturnsAsync((Drivers)null);

			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn400IfDriverSurnameLetterNotProvided()
		{
			var letter = '\0';
			var result = await controller.GetDrivers(letter);

			serviceMock.Verify(s => s.GetDrivers(letter), Times.Never);
			Assert.IsType<BadRequestResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnSingleDriver()
		{
			var driverId = 1;
			var driver = fixture.Create<DriverDetails>();
			serviceMock.Setup(s => s.GetDriver(driverId, null)).ReturnsAsync(driver);

			var result = await controller.GetDriver(driverId, null);

			serviceMock.Verify(s => s.GetDriver(driverId, null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfDriverNotFound()
		{
			var driverId = 2;
			serviceMock.Setup(s => s.GetDriver(driverId, null)).ReturnsAsync((DriverDetails)null);

			var result = await controller.GetDriver(driverId, null);

			serviceMock.Verify(s => s.GetDriver(driverId, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSearchDrivers()
		{
			var filter = "test filter";
			var searchResult = fixture.Create<SearchResult<DriverSummary>>();
			serviceMock.Setup(s => s.Search(filter, 1, 20)).ReturnsAsync(searchResult);

			var result = await controller.Search(filter);

			serviceMock.Verify(s => s.Search(filter, 1, 20), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(searchResult);
		}
	}
}
