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
	public class GridsControllerTests
	{
		private GridsController controller;
		private Fixture fixture;
		private Mock<IGridsService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public GridsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IGridsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new GridsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnGrid()
		{
			var raceId = 2000;
			var Grids = fixture.Create<GridInformation>();
			serviceMock.Setup(s => s.GetGrid(raceId)).ReturnsAsync(Grids);

			var result = await controller.GetGrid(raceId);

			serviceMock.Verify(s => s.GetGrid(raceId), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			Grids.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldReturn404IfGridNotFound()
		{
			var raceId = 2001;
			serviceMock.Setup(s => s.GetGrid(raceId)).ReturnsAsync((GridInformation)null);

			var result = await controller.GetGrid(raceId);

			serviceMock.Verify(s => s.GetGrid(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}
