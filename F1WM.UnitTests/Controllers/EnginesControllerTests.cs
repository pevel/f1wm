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
	public class EnginesControllerTests
	{
		private EnginesController controller;
		private Fixture fixture;
		private Mock<IEnginesService> serviceMock;

		public EnginesControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IEnginesService>();
			controller = new EnginesController(serviceMock.Object);
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

		[Fact]
		public async Task ShouldReturnEngine()
		{
			var engineId = 8888;
			var engine = fixture.Create<EngineDetails>();
			serviceMock.Setup(s => s.GetEngine(engineId)).ReturnsAsync(engine);

			var result = await controller.GetEngine(engineId);

			serviceMock.Verify(s => s.GetEngine(engineId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(engine);
		}

		[Fact]
		public async Task ShouldReturn404IfEngineNotFound()
		{
			var engineId = 9999;
			serviceMock.Setup(s => s.GetEngine(engineId)).ReturnsAsync((EngineDetails) null);

			var result = await controller.GetEngine(engineId);

			serviceMock.Verify(s => s.GetEngine(engineId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
