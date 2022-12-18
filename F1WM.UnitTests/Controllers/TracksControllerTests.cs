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
			var tracks = fixture.Create<PagedResult<Track>>();
			serviceMock.Setup(s => s.GetTracks(1, 25)).ReturnsAsync(tracks);

			var result = await controller.GetTracks(null);

			serviceMock.Verify(s => s.GetTracks(1, 25), Times.Once);
			result.Should().BeEquivalentTo(tracks);
		}

		[Fact]
		public async Task ShouldReturnTracksByStatusId()
		{
			byte status = 2;
			var tracks = fixture.Create<PagedResult<Track>>();
			serviceMock.Setup(s => s.GetTracksByStatus(status, 1, 25)).ReturnsAsync(tracks);

			var result = await controller.GetTracks(status);

			serviceMock.Verify(s => s.GetTracksByStatus(status, 1, 25), Times.Once);
			result.Should().BeEquivalentTo(tracks);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfTracksByStatusId()
		{
			byte status = 3;
			IEnumerable<Track> emptyResult = Enumerable.Empty<Track>();
			PagedResult<Track> emptyResponse = new PagedResult<Track>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.GetTracksByStatus(status, 1, 25)).ReturnsAsync(emptyResponse);

			var result = await controller.GetTracks(status);

			serviceMock.Verify(s => s.GetTracksByStatus(status, 1, 25), Times.Once);
			Assert.Empty(result.Result);
		}

		[Fact]
		public async Task ShouldReturnProperTracksCount()
		{
			int count = 5;

			await controller.GetTracks(null, 1, count);

			serviceMock.Verify(s => s.GetTracks(1, count), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnProperTracksPage()
		{
			int page = 2;

			await controller.GetTracks(null, page);

			serviceMock.Verify(s => s.GetTracks(page, 25), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnTrackDetails()
		{
			int id = 99999;
			var track = fixture.Create<TrackDetails>();
			serviceMock.Setup(s => s.GetTrack(id, null)).ReturnsAsync(track);

			var result = await controller.GetTrack(id, null);

			serviceMock.Verify(s => s.GetTrack(id, null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(track);
		}

		[Fact]
		public async Task ShouldReturn404IfTrackNotFound()
		{
			int id = 88888;
			serviceMock.Setup(s => s.GetTrack(id, null)).ReturnsAsync((TrackDetails)null);

			var result = await controller.GetTrack(id, null);

			serviceMock.Verify(s => s.GetTrack(id, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnTrackShortResultsByYears()
		{
			int id = 12345;
			var results = fixture.Create<TrackShortResultsByYears>();
			serviceMock.Setup(s => s.GetShortResultsByYears(id, null)).ReturnsAsync(results);

			var result = await controller.GetShortResultsByYears(id, null);

			serviceMock.Verify(s => s.GetShortResultsByYears(id, null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(results);
		}

		[Fact]
		public async Task ShouldReturn404IfTrackResultsNotFound()
		{
			int id = 54321;
			serviceMock.Setup(s => s.GetShortResultsByYears(id, null)).ReturnsAsync((TrackShortResultsByYears)null);

			var result = await controller.GetShortResultsByYears(id, null);

			serviceMock.Verify(s => s.GetShortResultsByYears(id, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
