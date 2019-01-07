using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
    public class CalendarServiceTests
    {
        private CalendarService service;
        private Mock<ICalendarRepository> calendarRepositoryMock;
        private Mock<ITimeService> timeServiceMock;

        public CalendarServiceTests()
        {
            calendarRepositoryMock = new Mock<ICalendarRepository>();
            timeServiceMock = new Mock<ITimeService>();
            service = new CalendarService(calendarRepositoryMock.Object, timeServiceMock.Object);
        }

        [Fact]
        public async Task ShouldGetCalendar()
        {
            var now = new DateTime(2016, 1, 1);
            timeServiceMock.SetupGet(t => t.Now).Returns(now);

            await service.GetCalendar(null);

            calendarRepositoryMock.Verify(r => r.GetCalendar(2016), Times.Once);
        }
    }
}
