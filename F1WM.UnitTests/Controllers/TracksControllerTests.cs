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
	public class TracksControllerTests
	{
		private TracksController controller;
		private Fixture fixture;
		private Mock<ITracksService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public TracksControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<ITracksService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new TracksController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnTrackRecordsWithoutYear()
		{
			var records = fixture.Create<TrackRecordsInformation>();
			int trackId = 111;
			int trackVersion = 222;
			serviceMock.Setup(s => s.GetTrackRecords(trackId, trackVersion, null)).ReturnsAsync(records);

			var result = await controller.GetTrackRecords(trackId, trackVersion, null);

			serviceMock.Verify(s => s.GetTrackRecords(trackId, trackVersion, null), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			records.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldReturnTrackRecordsWithYear()
		{
			var records = fixture.Create<TrackRecordsInformation>();
			int trackId = 333;
			int trackVersion = 444;
			int year = 2012;
			serviceMock.Setup(s => s.GetTrackRecords(trackId, trackVersion, year)).ReturnsAsync(records);

			var result = await controller.GetTrackRecords(trackId, trackVersion, year);

			serviceMock.Verify(s => s.GetTrackRecords(trackId, trackVersion, year), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			records.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldReturn404IfTrackRecordsNotFound()
		{
			int trackId = 555;
			int trackVersion = 666;
			serviceMock.Setup(s => s.GetTrackRecords(trackId, trackVersion, null)).ReturnsAsync((TrackRecordsInformation)null);

			var result = await controller.GetTrackRecords(trackId, trackVersion, null);

			serviceMock.Verify(s => s.GetTrackRecords(trackId, trackVersion, null), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}
