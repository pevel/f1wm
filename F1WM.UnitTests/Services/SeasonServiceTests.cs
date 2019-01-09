using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
    public class SeasonServiceTests
    {
        private SeasonService service;
        private Mock<ISeasonRepository> seasonRepositoryMock;
        private Mock<ITimeService> timeServiceMock;

        public SeasonServiceTests()
        {
            seasonRepositoryMock = new Mock<ISeasonRepository>();
            timeServiceMock = new Mock<ITimeService>();
            service = new SeasonService(seasonRepositoryMock.Object, timeServiceMock.Object);
        }

        [Fact]
        public async Task ShouldGetSeasonRules()
        {
            var now = new DateTime(2016, 1, 1);
            timeServiceMock.SetupGet(t => t.Now).Returns(now);

            await service.GetSeasonRules(null);

            seasonRepositoryMock.Verify(r => r.GetSeasonRules(2016), Times.Once);
        }
    }
}