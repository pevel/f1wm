using System;
using System.Threading.Tasks;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
    public class RacesServiceTests
	{
		private RacesService service;
		private Mock<IRacesRepository> repositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public RacesServiceTests()
		{
			repositoryMock = new Mock<IRacesRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new RacesService(repositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetNextRaceAfterToday()
		{
			var now = new DateTime(1992, 10, 14);
			timeServiceMock.SetupGet(t => t.Now).Returns(now);

			await service.GetNextRace();

			repositoryMock.Verify(r => r.GetFirstRaceAfter(now), Times.Once);
		}
	}
}