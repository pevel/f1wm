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
	public class BroadcastsControllerTests
	{
		private BroadcastsController controller;
		private Fixture fixture;
		private Mock<IBroadcastsService> serviceMock;

		public BroadcastsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IBroadcastsService>();
			controller = new BroadcastsController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextBroadcasts()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts()).ReturnsAsync(broadcasts);

			var result = await controller.GetNextBroadcasts();

			serviceMock.Verify(s => s.GetNextBroadcasts(), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			broadcasts.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts()).ReturnsAsync((BroadcastsInformation)null);

			var result = await controller.GetNextBroadcasts();

			serviceMock.Verify(s => s.GetNextBroadcasts(), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnBroadcasters()
		{
			var broadcasters = fixture.CreateMany<Broadcaster>();
			serviceMock.Setup(s => s.GetBroadcasters()).ReturnsAsync(broadcasters);

			var result = await controller.GetBroadcasters();

			serviceMock.Verify(s => s.GetBroadcasters(), Times.Once);
			broadcasters.Should().BeEquivalentTo(result);
		}

		[Fact]
		public async Task ShouldReturnBroadcastSessionTypes()
		{
			var types = fixture.CreateMany<BroadcastSessionType>();
			serviceMock.Setup(s => s.GetSessionTypes()).ReturnsAsync(types);

			var result = await controller.GetSessionTypes();

			serviceMock.Verify(s => s.GetSessionTypes(), Times.Once);
			types.Should().BeEquivalentTo(result);
		}

		[Fact]
		public async Task ShouldAddBroadcaster()
		{
			var request = fixture.Create<BroadcasterAddRequest>();
			var broadcaster = fixture.Create<Broadcaster>();
			serviceMock.Setup(s => s.AddBroadcaster(request)).ReturnsAsync(broadcaster);

			var result = await controller.AddBroadcaster(request);

			serviceMock.Verify(s => s.AddBroadcaster(request), Times.Once);
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
			broadcaster.Should().BeEquivalentTo(createdAtActionResult.Value);
		}

		[Fact]
		public async Task ShouldReturn422IfCouldNotAddBroadcaster()
		{
			var request = fixture.Create<BroadcasterAddRequest>();
			serviceMock.Setup(s => s.AddBroadcaster(request)).ReturnsAsync((Broadcaster)null);

			var result = await controller.AddBroadcaster(request);

			serviceMock.Verify(s => s.AddBroadcaster(request), Times.Once);
			Assert.IsType<UnprocessableEntityResult>(result.Result);
		}

		[Fact]
		public async Task ShouldAddBroadcastSessionType()
		{
			var request = fixture.Create<BroadcastSessionTypeAddRequest>();
			var type = fixture.Create<BroadcastSessionType>();
			serviceMock.Setup(s => s.AddSessionType(request)).ReturnsAsync(type);

			var result = await controller.AddSessionType(request);

			serviceMock.Verify(s => s.AddSessionType(request), Times.Once);
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
			type.Should().BeEquivalentTo(createdAtActionResult.Value);
		}

		[Fact]
		public async Task ShouldAddBroadcasts()
		{
			var request = fixture.Create<BroadcastsAddRequest>();
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.AddBroadcasts(request)).ReturnsAsync(broadcasts);

			var result = await controller.AddBroadcasts(request);

			serviceMock.Verify(s => s.AddBroadcasts(request), Times.Once);
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
			broadcasts.Should().BeEquivalentTo(createdAtActionResult.Value);
		}

		[Fact]
		public async Task ShouldReturn422IfCouldNotAddBroadcasts()
		{
			var request = fixture.Create<BroadcastsAddRequest>();;
			serviceMock.Setup(s => s.AddBroadcasts(request)).ReturnsAsync((BroadcastsInformation)null);

			var result = await controller.AddBroadcasts(request);

			serviceMock.Verify(s => s.AddBroadcasts(request), Times.Once);
			Assert.IsType<UnprocessableEntityResult>(result.Result);
		}
	}
}
