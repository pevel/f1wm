using F1WM.Repositories;
using F1WM.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class DriversServiceTests
	{
		private DriversService service;
		private Mock<IDriversRepository> driversRepositoryMock;
		private Mock<ITimeService> timeServiceMock;

		public DriversServiceTests()
		{
			driversRepositoryMock = new Mock<IDriversRepository>();
			timeServiceMock = new Mock<ITimeService>();
			service = new DriversService(driversRepositoryMock.Object, timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetDrivers()
		{
			char letter = 'r';

			await service.GetDrivers(letter);

			driversRepositoryMock.Verify(r => r.GetDrivers(letter), Times.Once);
		}

		[Fact]
		public async Task ShouldGetDriverInfoUntilCurrentYear()
		{
			var driverId = 9999;
			var currentYear = 1992;
			timeServiceMock.SetupGet(t => t.Now).Returns(new DateTime(currentYear, 1, 1));

			await service.GetDriver(driverId, null);

			driversRepositoryMock.Verify(r => r.GetDriver(driverId, currentYear), Times.Once);
		}

		[Fact]
		public async Task ShouldSearchDrivers()
		{
			var filter = "test filter";
			var page = 6666;
			var countPerPage = 9999;

			await service.Search(filter, page, countPerPage);

			driversRepositoryMock.Verify(r => r.Search(filter, page, countPerPage), Times.Once);
		}
	}
}
