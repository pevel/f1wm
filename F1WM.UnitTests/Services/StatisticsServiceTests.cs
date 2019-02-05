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
	}
}
