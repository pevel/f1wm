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
    public class SeasonsControllerTests
    {
        private SeasonsController controller;
        private Mock<ISeasonsService> serviceMock;
        private Mock<ILoggingService> loggerMock;
        private readonly int year = 2016;

        public SeasonsControllerTests()
        {
            serviceMock = new Mock<ISeasonsService>();
            loggerMock = new Mock<ILoggingService>();
            controller = new SeasonsController(serviceMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task ShouldReturnSeasonRules()
        {
            serviceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync(new SeasonRules());

            var result = await controller.GetSeasonRules(year);

            serviceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ShouldReturn404IfSeasonRulesNotFound()
        {
            serviceMock.Setup(s => s.GetSeasonRules(year)).ReturnsAsync((SeasonRules)null);

            var result = await controller.GetSeasonRules(year);

            serviceMock.Verify(s => s.GetSeasonRules(year), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
