using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
    public class SeasonsServiceTests
    {
        private SeasonsService service;
        private Mock<ISeasonsRepository> seasonRepositoryMock;
        private Mock<ITimeService> timeServiceMock;

        public SeasonsServiceTests()
        {
            seasonRepositoryMock = new Mock<ISeasonsRepository>();
            timeServiceMock = new Mock<ITimeService>();
            service = new SeasonsService(seasonRepositoryMock.Object, timeServiceMock.Object);
        }

        [Fact]
        public async Task ShouldGetSeasonRules()
        {
            var now = new DateTime(2016, 1, 1);
            timeServiceMock.SetupGet(t => t.Now).Returns(now);

            await service.GetSeasonRules(now.Year);

            seasonRepositoryMock.Verify(r => r.GetSeasonRules(2016), Times.Once);
        }

        [Fact]
        public async Task ShouldGetSeasonRulesWhenNoYearSpecified()
        {
            var now = DateTime.Now;
            timeServiceMock.SetupGet(t => t.Now).Returns(now);

            await service.GetSeasonRules(null);

            seasonRepositoryMock.Verify(r => r.GetSeasonRules(now.Year), Times.Once);
        }
    }
}