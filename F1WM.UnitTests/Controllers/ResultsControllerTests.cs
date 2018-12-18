using F1WM.Controllers;
using F1WM.Services;
using Moq;
using Xunit;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.UnitTests.Controllers
{
	public class ResultsControllerTests
	{
		private ResultsController controller;
		private Mock<IResultsService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public ResultsControllerTests()
		{
			serviceMock = new Mock<IResultsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new ResultsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnRaceResults()
		{
			int raceId = 42;

			await controller.GetRaceResult(raceId);

			serviceMock.Verify(s => s.GetRaceResult(raceId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceResultsNotFound()
		{
			int raceId = 43;
			serviceMock.Setup(s => s.GetRaceResult(raceId)).ReturnsAsync((RaceResult)null);

			var result = await controller.GetRaceResult(raceId);

			Assert.IsType<NotFoundResult>(result);
		}
	}
}