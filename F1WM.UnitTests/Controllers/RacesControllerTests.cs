using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using static F1WM.Utilities.Constants;

namespace F1WM.UnitTests.Controllers
{
	public class RacesControllerTests
	{
		private RacesController controller;
		private Fixture fixture;
		private Mock<IRacesService> racesServiceMock;
		private Mock<IStandingsService> standingsServiceMock;
		private Mock<ICachingService> cachingServiceMock;

		public RacesControllerTests()
		{
			fixture = new Fixture();
			racesServiceMock = new Mock<IRacesService>();
			standingsServiceMock = new Mock<IStandingsService>();
			cachingServiceMock = new Mock<ICachingService>();
			controller = new RacesController(racesServiceMock.Object, standingsServiceMock.Object, cachingServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextRace()
		{
			racesServiceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync(new NextRaceSummary());

			var result = await controller.GetNextRace(null);

			racesServiceMock.Verify(s => s.GetNextRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			racesServiceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync((NextRaceSummary)null);

			var result = await controller.GetNextRace(null);

			racesServiceMock.Verify(s => s.GetNextRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnLastRace()
		{
			racesServiceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync(new LastRaceSummary());

			var result = await controller.GetLastRace(null);

			racesServiceMock.Verify(s => s.GetLastRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfLastRaceNotFound()
		{
			racesServiceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync((LastRaceSummary)null);

			var result = await controller.GetLastRace(null);

			racesServiceMock.Verify(s => s.GetLastRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceNews()
		{
			var raceId = 1024;
			var fastestLaps = fixture.Create<RaceNews>();
			racesServiceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceNews(raceId);

			racesServiceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceNewsNotFound()
		{
			var raceId = 2048;
			racesServiceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync((RaceNews)null);

			var result = await controller.GetRaceNews(raceId);

			racesServiceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceFastestLaps()
		{
			var raceId = 256;
			var fastestLaps = fixture.Create<RaceFastestLaps>();
			racesServiceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceFastestLaps(raceId);

			racesServiceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceFastestLapsNotFound()
		{
			var raceId = 512;
			racesServiceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync((RaceFastestLaps)null);

			var result = await controller.GetRaceFastestLaps(raceId);

			racesServiceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnConstructorsStandingsAfterRace()
		{
			var raceId = 3;
			var fastestLaps = fixture.Create<ConstructorsStandingsAfterRace>();
			standingsServiceMock.Setup(s => s.GetConstructorsStandingsAfterRace(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetConstructorsStandingsAfterRace(raceId);

			standingsServiceMock.Verify(s => s.GetConstructorsStandingsAfterRace(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfConstructorsStandingsAfterRaceNotFound()
		{
			var raceId = 4;
			standingsServiceMock.Setup(s => s.GetConstructorsStandingsAfterRace(raceId)).ReturnsAsync((ConstructorsStandingsAfterRace)null);

			var result = await controller.GetConstructorsStandingsAfterRace(raceId);

			standingsServiceMock.Verify(s => s.GetConstructorsStandingsAfterRace(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnDriversStandingsAfterRace()
		{
			var raceId = 5;
			var fastestLaps = fixture.Create<DriversStandingsAfterRace>();
			standingsServiceMock.Setup(s => s.GetDriversStandingsAfterRace(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetDriversStandingsAfterRace(raceId);

			standingsServiceMock.Verify(s => s.GetDriversStandingsAfterRace(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfDriversStandingsAfterRaceNotFound()
		{
			var raceId = 6;
			standingsServiceMock.Setup(s => s.GetDriversStandingsAfterRace(raceId)).ReturnsAsync((DriversStandingsAfterRace)null);

			var result = await controller.GetDriversStandingsAfterRace(raceId);

			standingsServiceMock.Verify(s => s.GetDriversStandingsAfterRace(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnCachedNextRace()
		{
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.NextRace}_{requestParam}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<NextRaceSummary>(cacheKey)).Returns(new NextRaceSummary());

			var result = await controller.GetNextRace(requestParam);

			racesServiceMock.Verify(s => s.GetNextRace(requestParam), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<NextRaceSummary>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<NextRaceSummary>(), It.IsAny<TimeSpan>()), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnCachedLastRace()
		{
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.LastRace}_{requestParam}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<LastRaceSummary>(cacheKey)).Returns(new LastRaceSummary());

			var result = await controller.GetLastRace(requestParam);

			racesServiceMock.Verify(s => s.GetLastRace(requestParam), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<LastRaceSummary>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<LastRaceSummary>(), It.IsAny<TimeSpan>()), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSetNextRaceCache()
		{
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.NextRace}_{requestParam}";

			racesServiceMock.Setup(s => s.GetNextRace(requestParam)).ReturnsAsync(new NextRaceSummary());

			var result = await controller.GetNextRace(requestParam);

			racesServiceMock.Verify(s => s.GetNextRace(requestParam), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<NextRaceSummary>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<NextRaceSummary>(), It.IsAny<TimeSpan>()), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSetLastRaceCache()
		{
			DateTime? requestParam = null;
			var cacheKey = $"{CacheKeys.LastRace}_{requestParam}";

			racesServiceMock.Setup(s => s.GetLastRace(requestParam)).ReturnsAsync(new LastRaceSummary());

			var result = await controller.GetLastRace(requestParam);

			racesServiceMock.Verify(s => s.GetLastRace(requestParam), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<LastRaceSummary>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<LastRaceSummary>(), It.IsAny<TimeSpan>()), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}
	}
}
