using AutoFixture;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class StatisticsServiceTests
	{
		private StatisticsService service;
		private Fixture fixture;
		private Mock<IStatisticsRepository> repositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public StatisticsServiceTests()
		{
			fixture = new Fixture();
			timeServiceMock = new Mock<ITimeService>();
			repositoryMock = new Mock<IStatisticsRepository>();
			service = new StatisticsService(repositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetDriverStatisticsUntilCurrentYear()
		{
			var driverId = 987;
			var now = new DateTime(2012, 12, 21);
			var statistics = fixture.Create<DriverStatistics>();
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			repositoryMock.Setup(r => r.GetDriverStatistics(driverId, now.Year)).ReturnsAsync(statistics);

			var actual = await service.GetDriverStatistics(driverId, null);

			repositoryMock.Verify(r => r.GetDriverStatistics(driverId, now.Year), Times.Once);
			actual.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldGetDriverStatisticsUntilGivenYear()
		{
			var driverId = 654;
			var year = 1410;
			var statistics = fixture.Create<DriverStatistics>();
			repositoryMock.Setup(r => r.GetDriverStatistics(driverId, year)).ReturnsAsync(statistics);

			var actual = await service.GetDriverStatistics(driverId, year);

			repositoryMock.Verify(r => r.GetDriverStatistics(driverId, year), Times.Once);
			timeServiceMock.Verify(t => t.Now, Times.Never);
			actual.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldGetTeamStatisticsUntilCurrentYear()
		{
			var teamId = 321;
			var now = new DateTime(2000, 1, 1);
			var statistics = fixture.Create<TeamStatistics>();
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			repositoryMock.Setup(r => r.GetTeamStatistics(teamId, now.Year)).ReturnsAsync(statistics);

			var actual = await service.GetTeamStatistics(teamId, null);

			repositoryMock.Verify(r => r.GetTeamStatistics(teamId, now.Year), Times.Once);
			actual.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldGetTeamStatisticsUntilGivenYear()
		{
			var teamId = 123;
			var year = 966;
			var statistics = fixture.Create<TeamStatistics>();
			repositoryMock.Setup(r => r.GetTeamStatistics(teamId, year)).ReturnsAsync(statistics);

			var actual = await service.GetTeamStatistics(teamId, year);

			repositoryMock.Verify(r => r.GetTeamStatistics(teamId, year), Times.Once);
			timeServiceMock.Verify(t => t.Now, Times.Never);
			actual.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldGetEngineStatisticsUntilCurrentYear()
		{
			var engineId = 909;
			var now = new DateTime(2001, 2, 9);
			var statistics = fixture.Create<EngineStatistics>();
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			repositoryMock.Setup(r => r.GetEngineStatistics(engineId, now.Year)).ReturnsAsync(statistics);

			var actual = await service.GetEngineStatistics(engineId, null);

			repositoryMock.Verify(r => r.GetEngineStatistics(engineId, now.Year), Times.Once);
			actual.Should().BeEquivalentTo(statistics);
		}

		[Fact]
		public async Task ShouldGetEngineStatisticsUntilGivenYear()
		{
			var engineId = 808;
			var year = 2000;
			var statistics = fixture.Create<EngineStatistics>();
			repositoryMock.Setup(r => r.GetEngineStatistics(engineId, year)).ReturnsAsync(statistics);

			var actual = await service.GetEngineStatistics(engineId, year);

			repositoryMock.Verify(r => r.GetEngineStatistics(engineId, year), Times.Once);
			timeServiceMock.Verify(t => t.Now, Times.Never);
			actual.Should().BeEquivalentTo(statistics);
		}
	}
}
