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
	public class CalendarControllerTests
	{
		private CalendarController controller;
		private Mock<ICalendarService> serviceMock;
		private Mock<ICachingService> cachingServiceMock;

		public CalendarControllerTests()
		{
			serviceMock = new Mock<ICalendarService>();
			cachingServiceMock = new Mock<ICachingService>();
			controller = new CalendarController(serviceMock.Object, cachingServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnCalendar()
		{
			int year = 2016;
			serviceMock.Setup(s => s.GetCalendar(year)).ReturnsAsync(new Calendar());

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfCalendarNotFound()
		{
			int year = 2017;
			serviceMock.Setup(s => s.GetCalendar(year)).ReturnsAsync((Calendar)null);

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnCachedCalendar()
		{
			int year = 2016;
			var cacheKey = $"{CacheKeys.Calendar}_{year}";

			cachingServiceMock.Setup(c => c.TryGetCacheValue<Calendar>(cacheKey)).Returns(new Calendar());

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Never);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<Calendar>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<Calendar>(), It.IsAny<TimeSpan>()), Times.Never);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldSetCalendarCache()
		{
			int year = 2016;
			var cacheKey = $"{CacheKeys.Calendar}_{year}";

			serviceMock.Setup(s => s.GetCalendar(year)).ReturnsAsync(new Calendar());

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Once);
			cachingServiceMock.Verify(c => c.TryGetCacheValue<Calendar>(cacheKey), Times.Once);
			cachingServiceMock.Verify(c => c.Set(cacheKey, It.IsAny<Calendar>(), It.IsAny<TimeSpan>()), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}
	}
}
