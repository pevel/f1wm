using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class RacesControllerTests
	{
		private RacesController controller;
		private Fixture fixture;
		private Mock<IRacesService> serviceMock;

		public RacesControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IRacesService>();
			controller = new RacesController(serviceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextRace()
		{
			serviceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync(new NextRaceSummary());

			var result = await controller.GetNextRace(null);

			serviceMock.Verify(s => s.GetNextRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			serviceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync((NextRaceSummary)null);

			var result = await controller.GetNextRace(null);

			serviceMock.Verify(s => s.GetNextRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnLastRace()
		{
			serviceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync(new LastRaceSummary());

			var result = await controller.GetLastRace(null);

			serviceMock.Verify(s => s.GetLastRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfLastRaceNotFound()
		{
			serviceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync((LastRaceSummary)null);

			var result = await controller.GetLastRace(null);

			serviceMock.Verify(s => s.GetLastRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceNews()
		{
			var raceId = 1024;
			var fastestLaps = fixture.Create<RaceNews>();
			serviceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceNews(raceId);

			serviceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceNewsNotFound()
		{
			var raceId = 2048;
			serviceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync((RaceNews)null);

			var result = await controller.GetRaceNews(raceId);

			serviceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceFastestLaps()
		{
			var raceId = 256;
			var fastestLaps = fixture.Create<RaceFastestLaps>();
			serviceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceFastestLaps(raceId);

			serviceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceFastestLapsNotFound()
		{
			var raceId = 512;
			serviceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync((RaceFastestLaps)null);

			var result = await controller.GetRaceFastestLaps(raceId);

			serviceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
