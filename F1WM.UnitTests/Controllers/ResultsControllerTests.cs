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
			serviceMock.Setup(s => s.GetRaceResult(raceId)).ReturnsAsync(new RaceResult());

			var result = await controller.GetRaceResult(raceId);

			serviceMock.Verify(s => s.GetRaceResult(raceId), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceResultsNotFound()
		{
			int raceId = 43;
			serviceMock.Setup(s => s.GetRaceResult(raceId)).ReturnsAsync((RaceResult)null);

			var result = await controller.GetRaceResult(raceId);

			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task ShouldReturnQualifyingResults()
		{
			int raceId = 52;
			serviceMock.Setup(s => s.GetQualifyingResult(raceId)).ReturnsAsync(new QualifyingResult());

			var result = await controller.GetQualifyingResult(raceId);

			serviceMock.Verify(s => s.GetQualifyingResult(raceId), Times.Once);
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task ShouldReturn404IfQualifyingResultsNotFound()
		{
			int raceId = 53;
			serviceMock.Setup(s => s.GetQualifyingResult(raceId)).ReturnsAsync((QualifyingResult)null);

			var result = await controller.GetQualifyingResult(raceId);

			Assert.IsType<NotFoundResult>(result);
		}
	}
}