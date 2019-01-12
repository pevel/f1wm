using System;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class BroadcastsServiceTests
	{
		private BroadcastsService service;
		private Fixture fixture;
		private Mock<IBroadcastsRepository> repositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public BroadcastsServiceTests()
		{
			fixture = new Fixture();
			repositoryMock = new Mock<IBroadcastsRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new BroadcastsService(repositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldAddBroadcaster()
		{
			var request = fixture.Create<BroadcasterAddRequest>();

			await service.AddBroadcaster(request);

			repositoryMock.Verify(r => r.AddBroadcaster(request), Times.Once);
		}

		[Fact]
		public async Task ShouldGetBroadcasters()
		{
			var broadcasters = fixture.CreateMany<Broadcaster>();
			repositoryMock.Setup(r => r.GetBroadcasters()).ReturnsAsync(broadcasters);

			var result = await service.GetBroadcasters();

			repositoryMock.Verify(r => r.GetBroadcasters(), Times.Once);
			broadcasters.Should().BeEquivalentTo(result);
		}

		[Fact]
		public async Task ShouldAddBroadcasts()
		{
			var request = fixture.Create<BroadcastsAddRequest>();

			await service.AddBroadcasts(request);

			repositoryMock.Verify(r => r.AddBroadcasts(request), Times.Once);
		}

		[Fact]
		public async Task ShouldGetBroadcasts()
		{
			var broadcasts = fixture.Create<BroadcastsInformation>();
			var now = new DateTime(2001, 2, 9, 1, 2, 3);
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			repositoryMock.Setup(r => r.GetBroadcastsAfter(now)).ReturnsAsync(broadcasts);

			var result = await service.GetNextBroadcasts();

			repositoryMock.Verify(r => r.GetBroadcastsAfter(now), Times.Once);
			broadcasts.Should().BeEquivalentTo(result);
		}

		[Fact]
		public async Task ShouldAddBroadcastType()
		{
			var request = fixture.Create<BroadcastSessionTypeAddRequest>();

			await service.AddSessionType(request);

			repositoryMock.Verify(r => r.AddSessionType(request), Times.Once);
		}

		[Fact]
		public async Task ShouldGetBroadcastTypes()
		{
			var types = fixture.CreateMany<BroadcastSessionType>();
			repositoryMock.Setup(r => r.GetSessionTypes()).ReturnsAsync(types);

			var result = await service.GetSessionTypes();

			repositoryMock.Verify(r => r.GetSessionTypes(), Times.Once);
			types.Should().BeEquivalentTo(result);
		}
	}
}
