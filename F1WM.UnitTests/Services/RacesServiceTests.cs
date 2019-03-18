using System;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class RacesServiceTests
	{
		private RacesService service;
		private Fixture fixture;
		private Mock<IRacesRepository> racesRepositoryMock;
		private Mock<IResultsRepository> resultsRepositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public RacesServiceTests()
		{
			fixture = new Fixture();
			racesRepositoryMock = new Mock<IRacesRepository>();
			resultsRepositoryMock = new Mock<IResultsRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new RacesService(racesRepositoryMock.Object, resultsRepositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetNextRaceAfterToday()
		{
			var now = new DateTime(1992, 10, 14);
			timeServiceMock.SetupGet(t => t.Now).Returns(now);

			await service.GetNextRace(null);

			racesRepositoryMock.Verify(r => r.GetFirstRaceAfter(now), Times.Once);
		}

		[Fact]
		public async Task ShouldGetLastRaceBeforeTodayWithResults()
		{
			var now = new DateTime(1992, 10, 14);
			var raceId = 777;
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			racesRepositoryMock.Setup(r => r.GetMostRecentRaceBefore(now)).ReturnsAsync(new LastRaceSummary() { Id = raceId });

			await service.GetLastRace(null);

			racesRepositoryMock.Verify(r => r.GetMostRecentRaceBefore(now), Times.Once);
			resultsRepositoryMock.Verify(r => r.GetShortRaceResult(raceId), Times.Once);
		}

		[Fact]
		public async Task ShouldGetRaceNews()
		{
			var raceId = 999;
			var fastestLaps = fixture.Create<RaceNews>();
			racesRepositoryMock.Setup(r => r.GetRaceNews(raceId)).ReturnsAsync(fastestLaps);

			var actual = await service.GetRaceNews(raceId);

			racesRepositoryMock.Verify(r => r.GetRaceNews(raceId), Times.Once);
			actual.Should().BeEquivalentTo(fastestLaps);
		}

		[Fact]
		public async Task ShouldGetRaceFastestLaps()
		{
			var raceId = 888;
			var fastestLaps = fixture.Create<RaceFastestLaps>();
			racesRepositoryMock.Setup(r => r.GetRaceFastestLaps(raceId)).ReturnsAsync(fastestLaps);

			var actual = await service.GetRaceFastestLaps(raceId);

			racesRepositoryMock.Verify(r => r.GetRaceFastestLaps(raceId), Times.Once);
			actual.Should().BeEquivalentTo(fastestLaps);
		}
	}
}
