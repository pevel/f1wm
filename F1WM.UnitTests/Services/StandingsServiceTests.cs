using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class StandingsServiceTests
	{
		private StandingsService service;
		private Mock<IStandingsRepository> repositoryMock;

		public StandingsServiceTests()
		{
			repositoryMock = new Mock<IStandingsRepository>();
			service = new StandingsService(repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetConstructorsStandings()
		{
			int count = 101;
			int seasonId = 888;

			await service.GetConstructorsStandings(count, seasonId);

			repositoryMock.Verify(r => r.GetConstructorsStandings(count, seasonId), Times.Once);
		}

		[Fact]
		public async Task ShouldGetDriversStandings()
		{
			int count = 202;
			int seasonId = 999;

			await service.GetDriversStandings(count, seasonId);

			repositoryMock.Verify(r => r.GetDriversStandings(count, seasonId), Times.Once);
		}
	}
}