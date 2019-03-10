using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class SeasonsControllerTests
	{
		private SeasonsController controller;
		private Mock<ISeasonsService> seasonsServiceMock;
		private Mock<IEntriesService> entriesServiceMock;

		public SeasonsControllerTests()
		{
			seasonsServiceMock = new Mock<ISeasonsService>();
			entriesServiceMock = new Mock<IEntriesService>();
			controller = new SeasonsController(seasonsServiceMock.Object, entriesServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnSeasonRules()
		{
			int year = 2048;
			seasonsServiceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync(new SeasonRules());

			var result = await controller.GetSeasonRules(year);

			seasonsServiceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfSeasonRulesNotFound()
		{
			int year = 2049;
			seasonsServiceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync((SeasonRules)null);

			var result = await controller.GetSeasonRules(year);

			seasonsServiceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnSeasonEntries()
		{
			int year = 1024;
			entriesServiceMock
				.Setup(s => s.GetSeasonEntries(year))
				.ReturnsAsync(new SeasonEntriesInformation());

			var result = await controller.GetSeasonEntries(year);

			entriesServiceMock.Verify(s => s.GetSeasonEntries(year), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfSeasonEntriesNotFound()
		{
			int year = 1025;
			entriesServiceMock
				.Setup(s => s.GetSeasonEntries(year))
				.ReturnsAsync((SeasonEntriesInformation)null);

			var result = await controller.GetSeasonEntries(year);

			entriesServiceMock.Verify(s => s.GetSeasonEntries(year), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
