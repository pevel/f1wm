using System.Threading.Tasks;
using F1WM.Controllers;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class StandingsControllerTests
	{
		private StandingsController controller;
		private Mock<IStandingsService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public StandingsControllerTests()
		{
			serviceMock = new Mock<IStandingsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new StandingsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnFirst10ConstructorPositionsByDefault()
		{
			await controller.GetConstructorsStandings();

			serviceMock.Verify(s => s.GetConstructorsStandings(10, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnConstructorsStandingsBySeasonId()
		{
			int seasonId = 997;
			int count = 100;

			await controller.GetConstructorsStandings(seasonId, count);

			serviceMock.Verify(s => s.GetConstructorsStandings(count, seasonId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnFirst10DriverPositionsByDefault()
		{
			await controller.GetDriversStandings();

			serviceMock.Verify(s => s.GetDriversStandings(10, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnDriversStandingsBySeasonId()
		{
			int seasonId = 998;
			int count = 200;

			await controller.GetDriversStandings(seasonId, count);

			serviceMock.Verify(s => s.GetDriversStandings(count, seasonId), Times.Once);
		}
	}
}