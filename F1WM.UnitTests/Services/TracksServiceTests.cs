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
	public class TracksServiceTests
	{
		private TracksService service;
		private Fixture fixture;
		private Mock<ITracksRepository> repositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public TracksServiceTests()
		{
			fixture = new Fixture();
			repositoryMock = new Mock<ITracksRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new TracksService(repositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetTrackRecordsUntilCurrentYear()
		{
			var trackId = 1111;
			var trackVersion = 2222;
			var year = 2142;
			var records = fixture.Create<TrackRecordsInformation>();
			timeServiceMock.SetupGet(t => t.Now).Returns(new DateTime(year, 6, 6));
			repositoryMock.Setup(r => r.GetTrackRecords(trackId, trackVersion, year)).ReturnsAsync(records);

			var actual = await service.GetTrackRecords(trackId, trackVersion, null);

			repositoryMock.Verify(r => r.GetTrackRecords(trackId, trackVersion, year), Times.Once);
			actual.Should().BeEquivalentTo(records);
		}

		[Fact]
		public async Task ShouldGetTrackRecordsUntilSpecifiedYear()
		{
			var trackId = 3333;
			var trackVersion = 4444;
			var year = 2142;
			var records = fixture.Create<TrackRecordsInformation>();
			repositoryMock.Setup(r => r.GetTrackRecords(trackId, trackVersion, year)).ReturnsAsync(records);

			var actual = await service.GetTrackRecords(trackId, trackVersion, year);

			repositoryMock.Verify(r => r.GetTrackRecords(trackId, trackVersion, year), Times.Once);
			actual.Should().BeEquivalentTo(records);
		}
	}
}
