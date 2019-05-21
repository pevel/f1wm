using System;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.DomainModel;
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
		private Mock<ISeasonsRepository> seasonsRepositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public RacesServiceTests()
		{
			fixture = new Fixture();
			racesRepositoryMock = new Mock<IRacesRepository>();
			resultsRepositoryMock = new Mock<IResultsRepository>();
			seasonsRepositoryMock = new Mock<ISeasonsRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new RacesService(
				racesRepositoryMock.Object,
				resultsRepositoryMock.Object,
				seasonsRepositoryMock.Object,
				timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetNextRaceAfterDate()
		{
			var date = new DateTime(1992, 10, 14);

			await service.GetNextRace(date);

			racesRepositoryMock.Verify(r => r.GetFirstRaceAfter(date), Times.Once);
		}

		[Fact]
		public async Task ShouldGetLastRaceBeforeDateWithResults()
		{
			var date = new DateTime(1992, 10, 14);
			var raceId = 777;
			racesRepositoryMock.Setup(r => r.GetMostRecentRaceBefore(date)).ReturnsAsync(new LastRaceSummary() { Id = raceId });

			await service.GetLastRace(date);

			racesRepositoryMock.Verify(r => r.GetMostRecentRaceBefore(date), Times.Once);
			resultsRepositoryMock.Verify(r => r.GetShortRaceResult(raceId), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNextRaceAfterNow()
		{
			var now = new DateTime(1992, 10, 14);
			var seasonRaces = fixture.Create<SeasonRaces>();
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			seasonsRepositoryMock.Setup(s => s.GetCurrentSeasonRaces(now)).ReturnsAsync(seasonRaces);

			await service.GetNextRace();

			racesRepositoryMock.Verify(r => r.GetNextRace(seasonRaces), Times.Once);
		}

		[Fact]
		public async Task ShouldGetLastRaceBeforeNowWithResults()
		{
			var raceId = 111;
			var now = new DateTime(1992, 10, 14);
			var seasonRaces = fixture.Create<SeasonRaces>();
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			seasonsRepositoryMock.Setup(s => s.GetCurrentSeasonRaces(now)).ReturnsAsync(seasonRaces);
			racesRepositoryMock.Setup(r => r.GetMostRecentRace(seasonRaces)).ReturnsAsync(new LastRaceSummary() { Id = raceId });

			await service.GetLastRace();

			racesRepositoryMock.Verify(r => r.GetMostRecentRace(seasonRaces), Times.Once);
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
