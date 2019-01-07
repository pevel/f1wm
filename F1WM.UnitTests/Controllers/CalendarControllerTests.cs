using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class CalendarControllerTests
	{
		private CalendarController controller;
		private Mock<ICalendarService> serviceMock;
		private Mock<ILoggingService> loggerMock;
		private readonly int year = 2016;

		public CalendarControllerTests()
		{
			serviceMock = new Mock<ICalendarService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new CalendarController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnCalendar()
		{
			serviceMock.Setup(s => s.GetCalendar(year)).ReturnsAsync(new Calendar());

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfCalendarNotFound()
		{
			serviceMock.Setup(s => s.GetCalendar(year)).ReturnsAsync((Calendar)null);

			var result = await controller.GetCalendar(year);

			serviceMock.Verify(s => s.GetCalendar(year), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}