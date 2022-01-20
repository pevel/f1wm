using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using static F1WM.Utilities.Constants;

namespace F1WM.UnitTests.Controllers
{
	public class StandingsControllerTests
	{
		private StandingsController controller;
		private Mock<IStandingsService> serviceMock;
		private Mock<ICachingService> cachingServiceMock;

		public StandingsControllerTests()
		{
			serviceMock = new Mock<IStandingsService>();
			cachingServiceMock = new Mock<ICachingService>();
			controller = new StandingsController(serviceMock.Object, cachingServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnFirst10ConstructorPositionsByDefault()
		{
			await controller.GetConstructorsStandings();

			serviceMock.Verify(s => s.GetConstructorsStandings(10, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnConstructorsStandingsBySeasonId()
		{
			int seasonId = 997;
			int count = 100;

			await controller.GetConstructorsStandings(seasonId, count);

			serviceMock.Verify(s => s.GetConstructorsStandings(count, seasonId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnFirst10DriverPositionsByDefault()
		{
			await controller.GetDriversStandings();

			serviceMock.Verify(s => s.GetDriversStandings(10, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnDriversStandingsBySeasonId()
		{
			int seasonId = 998;
			int count = 200;

			await controller.GetDriversStandings(seasonId, count);

			serviceMock.Verify(s => s.GetDriversStandings(count, seasonId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnCachedConstructorsStandings()
		{
			int seasonId = 997;
			int count = 100;
			var cacheKey = $"{CacheKeys.ConstructorsStanding}_{seasonId}_{count}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<ConstructorsStandings>(cacheKey)).Returns(new ConstructorsStandings());

			var result = await controller.GetConstructorsStandings(seasonId, count);

			serviceMock.Verify(s => s.GetConstructorsStandings(count, seasonId), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<ConstructorsStandings>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<ConstructorsStandings>(), TimeSpan.FromDays(1)), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnCachedDriversStandings()
		{
			int seasonId = 997;
			int count = 100;
			var cacheKey = $"{CacheKeys.DriversStanding}_{seasonId}_{count}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<DriversStandings>(cacheKey)).Returns(new DriversStandings());

			var result = await controller.GetDriversStandings(seasonId, count);

			serviceMock.Verify(s => s.GetDriversStandings(count, seasonId), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<DriversStandings>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<DriversStandings>(), TimeSpan.FromDays(1)), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSetConstructorsStandingsCache()
		{
			int seasonId = 1;
			int count = 2;
			var cacheKey = $"{CacheKeys.ConstructorsStanding}_{seasonId}_{count}";

			serviceMock.Setup(s => s.GetConstructorsStandings(seasonId, count)).ReturnsAsync(new ConstructorsStandings());

			var result = await controller.GetConstructorsStandings(seasonId, count);

			serviceMock.Verify(s => s.GetConstructorsStandings(count, seasonId), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<ConstructorsStandings>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<ConstructorsStandings>(), TimeSpan.FromDays(1)), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSetDriversStandingsCache()
		{
			int seasonId = 1;
			int count = 2;
			var cacheKey = $"{CacheKeys.DriversStanding}_{seasonId}_{count}";

			serviceMock.Setup(s => s.GetDriversStandings(seasonId, count)).ReturnsAsync(new DriversStandings());

			var result = await controller.GetDriversStandings(seasonId, count);

			serviceMock.Verify(s => s.GetDriversStandings(count, seasonId), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<DriversStandings>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<DriversStandings>(), TimeSpan.FromDays(1)), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}
	}

}
