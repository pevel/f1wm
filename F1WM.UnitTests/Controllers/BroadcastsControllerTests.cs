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
		private Mock<ILoggingService> loggerMock;

		public BroadcastsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IBroadcastsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new BroadcastsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextBroadcasts()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts()).ReturnsAsync(broadcasts);

			var result = await controller.GetNextBroadcasts();

			serviceMock.Verify(s => s.GetNextBroadcasts(), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			broadcasts.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts()).ReturnsAsync((BroadcastsInformation)null);

			var result = await controller.GetNextBroadcasts();

			serviceMock.Verify(s => s.GetNextBroadcasts(), Times.Once);
			Assert.IsType<NotFoundResult>(result);
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
	}
}
