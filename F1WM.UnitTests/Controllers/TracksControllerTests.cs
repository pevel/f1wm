using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace F1WM.UnitTests.Controllers
{
	public class TracksControllerTests
	{
		private TracksController controller;
		private Fixture fixture;
		private Mock<ITracksService> serviceMock;

		public TracksControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<ITracksService>();
			controller = new TracksController(serviceMock.Object);
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
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			records.Should().BeEquivalentTo(okResult.Value);
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
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			records.Should().BeEquivalentTo(okResult.Value);
		}

		[Fact]
		public async Task ShouldReturn404IfTrackRecordsNotFound()
		{
			int trackId = 555;
			int trackVersion = 666;
			serviceMock.Setup(s => s.GetTrackRecords(trackId, trackVersion, null)).ReturnsAsync((TrackRecordsInformation)null);

			var result = await controller.GetTrackRecords(trackId, trackVersion, null);

			serviceMock.Verify(s => s.GetTrackRecords(trackId, trackVersion, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnTracks()
		{
			await controller.GetTracks(null);

			serviceMock.Verify(s => s.GetTracks(1, 25), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnTracksByStatusId()
		{
			byte statusId = 2;

			await controller.GetTracks(statusId);

			serviceMock.Verify(s => s.GetTracksByStatusId(statusId, 1, 25), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfTracksByStatusId()
		{
			byte statusId = 3;
			IEnumerable<TrackSummary> emptyResult = Enumerable.Empty<TrackSummary>();
			PagedResult<TrackSummary> emptyResponse = new PagedResult<TrackSummary>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.GetTracksByStatusId(statusId, 1, 25)).ReturnsAsync(emptyResponse);

			var result = await controller.GetTracks(statusId);

			serviceMock.Verify(s => s.GetTracksByStatusId(statusId, 1, 25), Times.Once);
			Assert.Empty(result.Result);
		}

		[Fact]
		public async Task ShouldReturnProperTracksCount()
		{
			var count = 5;

			await controller.GetTracks(null, 1, count);

			serviceMock.Verify(s => s.GetTracks(1, count), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnProperTracksPage()
		{
			var page = 2;

			await controller.GetTracks(null, page);

			serviceMock.Verify(s => s.GetTracks(page, 25), Times.Once);
		}
	}
}
