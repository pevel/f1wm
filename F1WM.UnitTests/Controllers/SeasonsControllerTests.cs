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
		private Mock<ISeasonsService> serviceMock;

		public SeasonsControllerTests()
		{
			serviceMock = new Mock<ISeasonsService>();
			controller = new SeasonsController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnSeasonRules()
		{
			int year = 2048;
			serviceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync(new SeasonRules());

			var result = await controller.GetSeasonRules(year);

			serviceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfSeasonRulesNotFound()
		{
			int year = 2049;
			serviceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync((SeasonRules)null);

			var result = await controller.GetSeasonRules(year);

			serviceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
