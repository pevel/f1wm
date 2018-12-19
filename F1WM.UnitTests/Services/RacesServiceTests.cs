using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class RacesServiceTests
	{
		private RacesService service;
		private Mock<IRacesRepository> racesRepositoryMock;
		private Mock<IResultsRepository> resultsRepositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public RacesServiceTests()
		{
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

			await service.GetNextRace();

			racesRepositoryMock.Verify(r => r.GetFirstRaceAfter(now), Times.Once);
		}

		[Fact]
		public async Task ShouldGetLastRaceBeforeTodayWithResults()
		{
			var now = new DateTime(1992, 10, 14);
			var raceId = 777;
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			racesRepositoryMock.Setup(r => r.GetMostRecentRaceBefore(now)).ReturnsAsync(new LastRaceSummary() { Id = raceId });

			await service.GetLastRace();

			racesRepositoryMock.Verify(r => r.GetMostRecentRaceBefore(now), Times.Once);
			resultsRepositoryMock.Verify(r => r.GetShortRaceResult(raceId), Times.Once);
		}
	}
}