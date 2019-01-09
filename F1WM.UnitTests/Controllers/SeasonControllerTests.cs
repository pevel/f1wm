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
    public class SeasonControllerTests
    {
        private SeasonController controller;
        private Mock<ISeasonService> serviceMock;
        private Mock<ILoggingService> loggerMock;
        private readonly int year = 2016;

        public SeasonControllerTests()
        {
            serviceMock = new Mock<ISeasonService>();
            loggerMock = new Mock<ILoggingService>();
            controller = new SeasonController(serviceMock.Object, loggerMock.Object);
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
