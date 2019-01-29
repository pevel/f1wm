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

		public CalendarControllerTests()
		{
			serviceMock = new Mock<ICalendarService>();
			controller = new CalendarController(serviceMock.Object);
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
	}
}
