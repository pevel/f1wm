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
	public class EnginesControllerTests
	{
		private EnginesController controller;
		private Mock<IEnginesService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public EnginesControllerTests()
		{
			serviceMock = new Mock<IEnginesService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new EnginesController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnEngines()
		{
			var letter = 'a';
			serviceMock.Setup(s => s.GetEngines(letter)).ReturnsAsync(new Engines());

			var result = await controller.GetEngines(letter);

			serviceMock.Verify(s => s.GetEngines(letter), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfEnginesNotFound()
		{
			var letter = 'a';
			serviceMock.Setup(s => s.GetEngines(letter)).ReturnsAsync((Engines) null);

			var result = await controller.GetEngines(letter);

			serviceMock.Verify(s => s.GetEngines(letter), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn400IfBadRequest()
		{
			char letter = '\0';

			var result = await controller.GetEngines(letter);
			
			Assert.IsType<BadRequestResult>(result.Result);
		}
	}
}
