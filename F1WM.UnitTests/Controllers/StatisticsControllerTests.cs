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
	public class StatisticsControllerTests
	{
		private StatisticsController controller;
		private Fixture fixture;
		private Mock<IStatisticsService> serviceMock;

		public StatisticsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IStatisticsService>();
			controller = new StatisticsController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnDriverStatistics()
		{
			var driverId = 777;
			var statistics = fixture.Create<DriverStatistics>();
			serviceMock.Setup(s => s.GetDriverStatistics(driverId, null)).ReturnsAsync(statistics);

			var result = await controller.GetDriverStatistics(driverId, null);

			serviceMock.Verify(s => s.GetDriverStatistics(driverId, null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldReturn404IfDriverStatisticsNotFound()
		{
			var driverId = 555;
			serviceMock.Setup(s => s.GetDriverStatistics(driverId, null)).ReturnsAsync((DriverStatistics)null);

			var result = await controller.GetDriverStatistics(driverId, null);

			serviceMock.Verify(s => s.GetDriverStatistics(driverId, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
