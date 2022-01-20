using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using System;
using static F1WM.Utilities.Constants;

namespace F1WM.UnitTests.Controllers
{
	public class BroadcastsControllerTests
	{
		private BroadcastsController controller;
		private Fixture fixture;
		private Mock<IBroadcastsService> serviceMock;
		private Mock<ICachingService> cachingServiceMock;

		public BroadcastsControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IBroadcastsService>();
			cachingServiceMock = new Mock<ICachingService>();
			controller = new BroadcastsController(serviceMock.Object, cachingServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextBroadcasts()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts(null)).ReturnsAsync(broadcasts);

			var result = await controller.GetNextBroadcasts(null);

			serviceMock.Verify(s => s.GetNextBroadcasts(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			broadcasts.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			serviceMock.Setup(s => s.GetNextBroadcasts(null)).ReturnsAsync((BroadcastsInformation)null);

			var result = await controller.GetNextBroadcasts(null);

			serviceMock.Verify(s => s.GetNextBroadcasts(null), Times.Once);
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
			cachingServiceMock.Verify(c => c.DisposeCache(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturn422IfCouldNotAddBroadcasts()
		{
			var request = fixture.Create<BroadcastsAddRequest>();
			serviceMock.Setup(s => s.AddBroadcasts(request)).ReturnsAsync((BroadcastsInformation)null);

			var result = await controller.AddBroadcasts(request);

			serviceMock.Verify(s => s.AddBroadcasts(request), Times.Once);
			Assert.IsType<UnprocessableEntityResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnCachedNextBroadcast()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.NextBroadcast}_{requestParam}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<BroadcastsInformation>(cacheKey)).Returns(broadcasts);

			var result = await controller.GetNextBroadcasts(requestParam);

			serviceMock.Verify(s => s.GetNextBroadcasts(requestParam), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<BroadcastsInformation>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<BroadcastsInformation>(), TimeSpan.FromDays(1)), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			broadcasts.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldSetNextBroadcastCache()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.NextBroadcast}_{requestParam}";

			serviceMock.Setup(s => s.GetNextBroadcasts(null)).ReturnsAsync(broadcasts);

			var result = await controller.GetNextBroadcasts(requestParam);

			serviceMock.Verify(s => s.GetNextBroadcasts(requestParam), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<BroadcastsInformation>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<BroadcastsInformation>(), TimeSpan.FromDays(1)), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			broadcasts.Should().BeEquivalentTo(okResult.Value);
		}
	}
}
