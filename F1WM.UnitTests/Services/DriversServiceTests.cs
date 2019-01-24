using F1WM.Repositories;
using F1WM.Services;
using Moq;
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
	}
}
