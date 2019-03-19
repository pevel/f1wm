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
		private Mock<IRacesService> racesServiceMock;
		private Mock<IStandingsService> standingsServiceMock;

		public RacesControllerTests()
		{
			fixture = new Fixture();
			racesServiceMock = new Mock<IRacesService>();
			standingsServiceMock = new Mock<IStandingsService>();
			controller = new RacesController(racesServiceMock.Object, standingsServiceMock.Object);
		}

		[Fact]
		public async Task ShouldReturnNextRace()
		{
			racesServiceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync(new NextRaceSummary());

			var result = await controller.GetNextRace(null);

			racesServiceMock.Verify(s => s.GetNextRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfNextRaceNotFound()
		{
			racesServiceMock.Setup(s => s.GetNextRace(null)).ReturnsAsync((NextRaceSummary)null);

			var result = await controller.GetNextRace(null);

			racesServiceMock.Verify(s => s.GetNextRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnLastRace()
		{
			racesServiceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync(new LastRaceSummary());

			var result = await controller.GetLastRace(null);

			racesServiceMock.Verify(s => s.GetLastRace(null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturn404IfLastRaceNotFound()
		{
			racesServiceMock.Setup(s => s.GetLastRace(null)).ReturnsAsync((LastRaceSummary)null);

			var result = await controller.GetLastRace(null);

			racesServiceMock.Verify(s => s.GetLastRace(null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceNews()
		{
			var raceId = 1024;
			var fastestLaps = fixture.Create<RaceNews>();
			racesServiceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceNews(raceId);

			racesServiceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceNewsNotFound()
		{
			var raceId = 2048;
			racesServiceMock.Setup(s => s.GetRaceNews(raceId)).ReturnsAsync((RaceNews)null);

			var result = await controller.GetRaceNews(raceId);

			racesServiceMock.Verify(s => s.GetRaceNews(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRaceFastestLaps()
		{
			var raceId = 256;
			var fastestLaps = fixture.Create<RaceFastestLaps>();
			racesServiceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync(fastestLaps);

			var result = await controller.GetRaceFastestLaps(raceId);

			racesServiceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldReturn404IfRaceFastestLapsNotFound()
		{
			var raceId = 512;
			racesServiceMock.Setup(s => s.GetRaceFastestLaps(raceId)).ReturnsAsync((RaceFastestLaps)null);

			var result = await controller.GetRaceFastestLaps(raceId);

			racesServiceMock.Verify(s => s.GetRaceFastestLaps(raceId), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
