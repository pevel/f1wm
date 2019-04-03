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

		public RacesServiceTests()
		{
			fixture = new Fixture();
			racesRepositoryMock = new Mock<IRacesRepository>();
			resultsRepositoryMock = new Mock<IResultsRepository>();
			service = new RacesService(racesRepositoryMock.Object, resultsRepositoryMock.Object);
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
		public async Task ShouldGetNextRace()
		{
			await service.GetNextRace();

			racesRepositoryMock.Verify(r => r.GetNextRace(), Times.Once);
		}

		[Fact]
		public async Task ShouldGetLastRaceWithResults()
		{
			var raceId = 111;
			racesRepositoryMock.Setup(r => r.GetMostRecentRace()).ReturnsAsync(new LastRaceSummary() { Id = raceId });

			await service.GetLastRace();

			racesRepositoryMock.Verify(r => r.GetMostRecentRace(), Times.Once);
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
